using MirrorMakerIICore.Infra;
using ScannerCore;
using static MirrorMakerIICore.Shared;
#pragma warning disable 8604, 8602, 8600

namespace MirrorMakerIICore
{
    internal class Comparer : IProgress
    {
        public double Progress { get; private set; }

        public string Current { get; private set; } = "Comparing...";

        public (OperationSummary, List<string>) Compare (FsItem fsSrc, FsItem fsDst, MMLogger l)
        {
            //The processing directive
            OperationSummary operation = new();
            //Flat views of the tree diffs
            Dictionary<string, FsItem> flSrc = new(),
                                       flDst = new();

            //Process file trees, find differences
            var backupFolders = RemoveBackups(fsDst);
            Compare(fsSrc, fsDst);
            l.Basic("Compare complete.");

            //Classify differences found
            FlattenTree(fsSrc, null, flSrc);
            FlattenTree(fsDst, null, flDst);
            l.Basic("Flattening complete.");

            operation.FoldersToMaybeCreate = GetUniqueFolders(flSrc.Keys, flDst.Keys, fsSrc.Name, fsDst.Name).Select(f => fsDst.Name + f).ToList();
            operation.FoldersToMaybeDelete = GetUniqueFolders(flDst.Keys, flSrc.Keys, fsDst.Name, fsSrc.Name).Select(f => fsDst.Name + f).ToList();
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
                                             To = Rebase(pair.To, fsSrc.Name, fsDst.Name)
                                         })
                                         .ToList();
            foreach (var moveFrom in operation.FilesToMove)
            {
                flDst.Remove(moveFrom.From);
                flSrc.Remove(moveFrom.FromReference);
            }
            //this is how we can get _purely_ deleted files
            //operation.FilesToDelete = flDst.Keys.Where(d => !flSrc.ContainsKey(Rebase(d, fsDst.Name, fsSrc.Name))).ToList();
            //however, for the backup purposes, we also want to take the files that were updated, and will be overwritten
            operation.FilesToDelete = flDst.Keys.ToList();
            operation.FilesToCopy = flSrc.Keys.Select(k => new FileReference()
                                               {
                                                   From = k,
                                                   To = Rebase(k, fsSrc.Name, fsDst.Name)
                                               })
                                              .ToList();
            Progress = 1.0;
            Current = "Sync preparation complete.";
            l.Basic(Current);

            return (operation, backupFolders);
        }

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
                    if (dItem != null) //matched by name and Dir attribute
                    {
                        if (sItem.IsDir)
                        {
                            Compare(sItem, dItem);
                            if (sItem.Items.Count == 0) source.Items.RemoveAt(s);
                            if (dItem.Items.Count == 0) destination.Items.RemoveAt(d);
                        }
                        else if (sItem.LastModified == dItem.LastModified && sItem.Size == dItem.Size) //file is uidentical and not changed - remove from lists = do not touch
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
    }
}
