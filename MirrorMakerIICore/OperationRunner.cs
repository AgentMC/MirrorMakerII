﻿using MirrorMakerIICore.Infra;
using Log = System.Action<string>;
using Log2 = System.Action<string, string>;
#pragma warning disable 8604, 8602, 8600

namespace MirrorMakerIICore
{
    internal class OperationRunner : IProgressEx
    {
        internal const string BackupFormat = "$mm$bckp$";

        readonly MMLogger l;

        readonly List<string> createdFolders = new();
        string? destinationBackupPath = null;


        public double Progress { get; private set; }

        public string Current { get; private set; } = "Starting file operations.";

        public void SetCurrent(string value) => Current = value;


        public OperationRunner(MMLogger logger)
        {
            l = logger;
            l.StatusReflector = this;
        }

        public void Run (OperationSummary operation, List<string> backupFolders, int backupLevel, string destination)
        {
            //Execute
            /* exec order:
             * 0. Backup folders pre-processing                                                          5%
             * 0.A. From 9 to max(backupLevel-1, 0) excl. - delete backup folders recursively            
             * 0.B. If backupLevel > 1 from backupLevel-1 to 1 - increment backup counter on folder      
             * 1. Create folders if necessary, recoursive                                                5%
             * 2.A. Delete files if backup level == 0                                                    
             * 2.B. Move files to backup folder if backup level > 0                                      8%
             * 3. Move files                                                                             4%
             * 4. Copy files                                                                             75%
             * 5. Delete folders if necessary, reverse-recoursive                                        3%
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
            Progress = 0.05;
            l.Basic("Backups refresh complete.");
            foreach (var createFolder in operation.FoldersToMaybeCreate)
            {
                CreateFolderIfNecessaryRecoursive(createFolder, false);
                Progress += 0.05 / operation.FoldersToMaybeCreate.Count;
            }
            Progress = 0.1;
            bool backupFolderCreated = false;
            foreach (var deleteFile in operation.FilesToDelete)
            {
                if (backupLevel == 0)
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
                    var newPath = Shared.Rebase(deleteFile, destination, destinationBackupPath);
                    var newPathFodler = Path.GetDirectoryName(newPath);
                    CreateFolderIfNecessaryRecoursive(newPathFodler, true);
                    MoveExistingFile(deleteFile, newPath, true);
                }
                Progress += 0.08 / operation.FilesToDelete.Count;
            }
            Progress = 0.18;
            foreach (var moveFile in operation.FilesToMove)
            {
                MoveExistingFile(moveFile.From, moveFile.To, false);
                Progress += 0.04 / operation.FilesToMove.Count;
            }
            Progress = 0.22;
            foreach (var copyFile in operation.FilesToCopy)
            {
                Current = $"Copying file: {copyFile.From} => {copyFile.To}";
                CopyNewFile(copyFile.From, copyFile.To);
                Progress += 0.75 / operation.FilesToCopy.Count;
            }
            Progress = 0.97;
            foreach (var deleteFolder in operation.FoldersToMaybeDelete)
            {
                DeleteOldFolderIfNecessaryRecursive(deleteFolder, destination);
                Progress += 0.03 / operation.FoldersToMaybeDelete.Count;
            }
            Progress = 1;
            l.Basic("Sync complete.");
            l.StatusReflector = null;
        }

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
    }
}