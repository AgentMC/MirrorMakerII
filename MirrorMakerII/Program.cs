using ScannerCore;
using MirrorMakerII;

string source = @"D:\hackd",
       destination = @"Z:\Backup\Mike";

var runners = new List<Thread>();
//File System Tree objects
FsItem fsSrc = null, fsDst = null;
//Scanner objects
DriveScanner scSrc = new DriveScanner(), scDst = new DriveScanner();
//Threads
Thread thSrc = new Thread(() => fsSrc = scSrc.ScanDirectory(source)), thDst = new Thread(() => fsDst = scDst.ScanDirectory(destination));
//Flat views of the tree diffs
Dictionary<string, FsItem> flSrc = new Dictionary<string, FsItem>(), flDst = new Dictionary<string, FsItem>();
//The processing directive
OperationSummary operation = new OperationSummary();

runners.Add(thSrc);
runners.Add(thDst);
runners.ForEach(runner => runner.Start());
while (runners.Any(r => r.IsAlive))
{
    Console.WriteLine($"S => {(thSrc.IsAlive ? scSrc.CurrentScanned : "completed.")}");
    Console.WriteLine($"D => {(thDst.IsAlive ? scDst.CurrentScanned : "completed.")}");
    Thread.Sleep(100);
}
//runners.ForEach(runner => runner.Join());

var backupFolders = RemoveBackups(fsDst);
Compare(fsSrc, fsDst);
Console.WriteLine("Compare complete.");

FlattenTree(fsSrc, null, flSrc);
FlattenTree(fsDst, null, flDst);
Console.WriteLine("Flattening complete.");

operation.FoldersToMaybeCreate = GetUniqueFolders(flSrc.Keys, flDst.Keys, source, destination).Select(f => destination + f).ToList();
operation.FoldersToMaybeDelete = GetUniqueFolders(flDst.Keys, flSrc.Keys, destination, source).Select(f => destination + f).ToList();
operation.FilesToMove = flDst.Select(d => new
                                    {
                                        From = d,
                                        To = flSrc.FirstOrDefault(s => s.Value.Name.Equals(d.Value.Name, StringComparison.OrdinalIgnoreCase)
                                                                    && s.Value.Size == d.Value.Size
                                                                    && s.Value.LastModified == d.Value.LastModified)
                                    })
                             .Where(pair => pair.To.Key != null)
                             .ToDictionary(pair => pair.From.Key, pair => pair.To.Key);
foreach (var moveFrom in operation.FilesToMove)
{
    flDst.Remove(moveFrom.Key);
    flSrc.Remove(moveFrom.Value);
}
operation.FilesToDelete = flDst.Keys.Where(d => !flSrc.ContainsKey(source + d.Substring(destination.Length))).ToList();
operation.FilesToCopy = flSrc.Keys.ToDictionary(k => k, k => destination + k.Substring(source.Length));



Console.ReadKey();

static List<string> RemoveBackups(FsItem destination)
{
    var result = new List<string>();
    for (int i = destination.Items.Count - 1; i >= 0; i--)
    {
        FsItem? item = destination.Items[i];
        if (item.Name.StartsWith("$mm$bckp$"))
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
