﻿using ScannerCore;
using MirrorMakerII;
using Log = System.Action<string>;
using Log2 = System.Action<string, string>;

#pragma warning disable 8604, 8602, 8600

const string BackupFormat = "$mm$bckp$";
//string source = @"D:\hackd",
//       destination = @"Z:\Backup\Mike";
string source = @"D:\hackd\Pix",
       destination = @"C:\Temp",
       destinationBackupPath = null;
int    backupLevel = 1;


var runners = new List<Thread>();
//File System Tree objects
FsItem fsSrc = null, 
       fsDst = null;
//Scanner objects
DriveScanner scSrc = new(), 
             scDst = new();
//Threads
Thread thSrc = new(() => fsSrc = scSrc.ScanDirectory(source)), 
       thDst = new(() => fsDst = scDst.ScanDirectory(destination));
//Flat views of the tree diffs
Dictionary<string, FsItem> flSrc = new(), 
                           flDst = new();
//The processing directive
OperationSummary operation = new();
//Logger
var l = new MMLogger(null);

//Scan
l.Start(source, destination, backupLevel);
runners.Add(thSrc);
runners.Add(thDst);
runners.ForEach(runner => runner.Start());
#if DEBUG
while (runners.Any(r => r.IsAlive))
{
    Console.WriteLine($"S => {(thSrc.IsAlive ? scSrc.CurrentScanned : "completed.")}");
    Console.WriteLine($"D => {(thDst.IsAlive ? scDst.CurrentScanned : "completed.")}");
    Thread.Sleep(100);
}
#else
runners.ForEach(runner => runner.Join());
#endif
l.Basic("Tree building complete.");

//Process file trees, find differences
var backupFolders = RemoveBackups(fsDst); 
Compare(fsSrc, fsDst);
l.Basic("Compare complete.");

//Classify differences found
FlattenTree(fsSrc, null, flSrc);
FlattenTree(fsDst, null, flDst);
l.Basic("Flattening complete.");

operation.FoldersToMaybeCreate = GetUniqueFolders(flSrc.Keys, flDst.Keys, source, destination).Select(f => destination + f).ToList();
operation.FoldersToMaybeDelete = GetUniqueFolders(flDst.Keys, flSrc.Keys, destination, source).Select(f => destination + f).ToList();
operation.FilesToMove = flDst.Select(d => new
                             {
                                 From = d.Key,
                                 To = flSrc.FirstOrDefault(s => s.Value.Name.Equals(d.Value.Name, StringComparison.OrdinalIgnoreCase)
                                                             && s.Value.Size == d.Value.Size
                                                             && s.Value.LastModified == d.Value.LastModified)
                                           .Key
                             })
                             .Where(pair => pair.To != null)
                             .Select(pair => new FileReference()
                             {
                                 From = pair.From,
                                 FromReference = pair.To,
                                 To = Rebase(pair.To, source, destination)
                             })
                             .ToList();
foreach (var moveFrom in operation.FilesToMove)
{
    flDst.Remove(moveFrom.From);
    flSrc.Remove(moveFrom.FromReference);
}
operation.FilesToDelete = flDst.Keys.Where(d => !flSrc.ContainsKey(Rebase(d, destination, source))).ToList();
operation.FilesToCopy = flSrc.Keys.Select(k => new FileReference()
                                   {
                                       From = k,
                                       To = Rebase(k, source, destination)
                                   })
                                   .ToList();
l.Basic("Sync preparation complete.");

//Execute
/* exec order:
 * 0. Backup folders pre-processing
 * 0.A. From 9 to max(backupLevel-1, 0) excl. - delete backup folders recursively
 * 0.B. If backupLevel > 1 from backupLevel-1 to 1 - increment backup counter on folder
 * 1. Create folders if necessary, recoursive
 * 2.A. Delete files if backup level == 0
 * 2.B. Move files to backup folder if backup level > 0
 * 3. Move files
 * 4. Copy files
 * 5. Delete folders if necessary, reverse-recoursive
*/
for (int i = 9; i > 0; i--)
{
    var backupFolderName = BackupFormat + i;
    var oldPath = Path.Combine(destination, backupFolderName);
    var newPath = Path.Combine(destination, BackupFormat + (i + 1));

    if (backupFolders.Contains(backupFolderName))
    {
        if (i >= backupLevel)
        {
            DeleteBackupFolder(oldPath);
        }
        else
        {
            ShiftBackupFolder(oldPath, newPath);
        }
    }
    destinationBackupPath = oldPath;
}
foreach (var createFolder in operation.FoldersToMaybeCreate)
{
    CreateFolderIfNecessaryRecoursive(createFolder, false);
}
bool backupFolderCreated = false;
foreach (var deleteFile in operation.FilesToDelete)
{
    if(backupLevel == 0)
    {
        DeleteOldFile(deleteFile);
    }
    else
    {
        if (!backupFolderCreated)
        {
            CreateFolderIfNecessaryRecoursive(destinationBackupPath, true);
            backupFolderCreated = true;
        }
        var newPath = Rebase(deleteFile, destination, destinationBackupPath);
        var newPathFodler = Path.GetDirectoryName(newPath);
        CreateFolderIfNecessaryRecoursive(newPathFodler, true);
        MoveExistingFile(deleteFile, newPath, true);
    }
}
foreach (var moveFile in operation.FilesToMove)
{
    MoveExistingFile(moveFile.From, moveFile.To, false);
}
foreach (var copyFile in operation.FilesToCopy)
{
    CopyNewFile(copyFile.From, copyFile.To);
}
foreach (var deleteFolder in operation.FoldersToMaybeDelete)
{
    DeleteOldFolderIfNecessaryRecursive(deleteFolder, destination);
}
l.Basic("Sync complete.");

static List<string> RemoveBackups(FsItem destination)
{
    var result = new List<string>();
    for (int i = destination.Items.Count - 1; i >= 0; i--)
    {
        FsItem? item = destination.Items[i];
        if (item.Name.StartsWith(BackupFormat))
        {
            result.Add(item.Name);
            destination.Items.RemoveAt(i);
        }
    }
    return result;
}

static void Compare(FsItem source, FsItem destination)
{
    for (int s = source.Items.Count - 1; s >= 0; s--)
    {
        var sItem = source.Items[s];
        int d = destination.Items.Count;
        if (d > 0)
        {
            FsItem? dItem;
            do
            {
                d--;
                dItem = d >= 0 ? destination.Items[d] : null;
            } while (dItem != null && (!dItem.Name.Equals(sItem.Name, StringComparison.OrdinalIgnoreCase) || dItem.IsDir != sItem.IsDir));
            if (dItem != null) //matched
            {
                if (sItem.IsDir)
                {
                    Compare(sItem, dItem);
                    if (sItem.Items.Count == 0) source.Items.RemoveAt(s);
                    if (dItem.Items.Count == 0) destination.Items.RemoveAt(d);
                }
                else if (sItem.LastModified == dItem.LastModified && sItem.Size == dItem.Size)
                {
                    source.Items.RemoveAt(s);
                    destination.Items.RemoveAt(d);
                }
            }
        }
    }
}

static void FlattenTree(FsItem fsItem, string? location, Dictionary<string, FsItem> host)
{
    location = (location ?? string.Empty) + (fsItem.Name + Path.DirectorySeparatorChar);
    foreach (var item in fsItem.Items)
    {
        if (item.IsDir)
        {
            FlattenTree(item, location, host);
        }
        else
        {
            host[location + item.Name] = item;
        }
    }
}

static IEnumerable<string> GetUniqueFolders(IEnumerable<string> fromCollection, IEnumerable<string> exceptCollection, string fromRoot, string exceptRoot)
{
    var key2Path = (IEnumerable<string> e, int rootLength) => e.Select(key => Path.GetDirectoryName(key).Substring(rootLength)).Distinct();
    return key2Path(fromCollection, fromRoot.Length).Except(key2Path(exceptCollection, exceptRoot.Length), StringComparer.OrdinalIgnoreCase);
}

List<string> createdFolders = new();
void CreateFolderIfNecessaryRecoursive(string folder, bool backupActivity)
{
    if (createdFolders.Contains(folder)) return;
    try
    {
        Directory.CreateDirectory(folder);
        ((Log)(backupActivity ? l.BackupFolderCreate : l.MirrorFolderCreate))(folder);
        createdFolders.Add(folder);
    }
    catch (Exception ex)
    {
        l.ErrorFolderCreate(folder, ex);
    }
}

void MoveExistingFile(string from, string to, bool backupActivity)
{
    try
    {
        File.Move(from, to, true);
        ((Log2)(backupActivity ? l.BackupFileMove : l.MirrorFileMove))(from, to);
    }
    catch (Exception ex)
    {
        l.ErrorFileMove(from, to, ex);
    }
}

void CopyNewFile(string from, string to)
{
    try
    {
        File.Copy(from, to, true);
        l.MirrorFileCopy(from, to);
    }
    catch (Exception ex)
    {
        l.ErrorFileCopy(from, to, ex);
    }
}

void DeleteOldFile(string file)
{
    try
    {
        File.Delete(file);
        l.MirrorFileDelete(file);
    }
    catch (Exception ex)
    {
        l.ErrorFileDelete(file, ex);
    }
}

void DeleteOldFolderIfNecessaryRecursive(string folder, string root)
{
    try
    {
        while (!string.Equals(folder, root, StringComparison.OrdinalIgnoreCase) && !Directory.EnumerateFileSystemEntries(folder).Any())
        {
            Directory.Delete(folder);
            l.MirrorFolderDelete(folder);
            folder = Path.GetDirectoryName(folder);
        }
    }
    catch (Exception ex)
    {
        l.ErrorFolderDelete(folder, ex);
    }
}

void DeleteBackupFolder(string folder)
{
    try
    {
        Directory.Delete(folder, true);
        l.BackupFolderDelete(folder);
    }
    catch (Exception ex)
    {
        l.ErrorFolderDelete(folder, ex);
    }
}

void ShiftBackupFolder(string oldFolder, string newFolder)
{
    try
    {
        Directory.Move(oldFolder, newFolder);
        l.BackupFolderMove(oldFolder, newFolder);
    }
    catch (Exception ex)
    {
        l.ErrorFolderMove(oldFolder, newFolder, ex);
    }
}

static string Rebase(string path, string pathRoot, string newRoot)
{
    return newRoot + path.Substring(pathRoot.Length);
    //return string.Concat(newRoot, path.AsSpan(pathRoot.Length));
}