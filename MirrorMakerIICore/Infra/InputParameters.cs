using System.Text;

#pragma warning disable CS8604 // Possible null reference argument.

namespace MirrorMakerIICore.Infra
{
    public class InputParameters
    {
        public readonly IReadOnlyList<InputEntry> Entries;
        public readonly string? Error;
        public readonly RunMode Mode;

        public InputParameters(string Source, string Destination, int Backup) : this(Array.Empty<string>()) 
        {
            Mode = RunMode.Default;
            ((List<InputEntry>)Entries).Add(new InputEntry(Source, Destination, Backup));
        }

        public InputParameters(string[] args)
        {
            var entries = new List<InputEntry>();
            Entries = entries;
            if (args.Length == 1 && File.Exists(args[0]))
            {
                Mode = RunMode.Batch;
                using var batchInput = new StreamReader(args[0], Encoding.UTF8);
                string? row;
                int rowNr = 0;
                while ((row = batchInput.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(row) || row.StartsWith("\\\\"))
                    {
                        continue;
                    }
                    rowNr++;
                    var entry = ParseEntry(row);
                    if (entry.Item2 != null)
                    {
                        Error = $"Unable to parse batch input [{args[0]}]. Error in row {rowNr}:\r\n>>{row}\r\n::{entry.Item2}.\r\nPlease ensure every row is\r\n<Source folder (existing, quoted if necessary)> <Destination folder (existing, quoted if necessary)> [<optional backup level: int 0 - 9>].";
                        return;
                    }
                    entries.Add(entry.Item1);
                }
            }
            else if (args.Length == 2 || args.Length == 3)
            {
                Mode = default;
                var check = CheckArgs(args);
                if (check.Item2 != null)
                {
                    Error = check.Item2;
                    return;
                }
                entries.Add(check.Item1);
            }
            else if (args.Length == 0)
            {
                Mode = RunMode.Gui;
            }
            else
            {
                Error =
@"Mirror Maker II is a one-directional folder sync tool supporting nested increnmental backup system.

1. Default invokation: MMII.exe Source Destination [Backup level]

Source and Destination are both folder paths. If either contains a space, use ""quotes"".

Backup level is an optional integer in the range 0 - 9. Default value is 0.
When specified and > 0, MMII will create in the destination nested folders starting with " + OperationRunner.BackupFormat +
@", each of which containing the files deleted in the Source in the previous syncs. For example, if you have set Backup level to 7, and MMII runs every day, you can recover files deleted a week ago.

2. Batch invokation: MMII.exe BatchFile.Name

Batch file name is the name/path to the text file, each row of which follows the structure
    Source Destination [Backup level]
as explained above. Empty rows are ignored. Comments are supported when line starts with \\.";
            }
        }

        private static (InputEntry?, string?) ParseEntry(string row)
        {
            var parts = row.Split(" ");
            var blocks = new List<string>();
            bool newWord = true;
            foreach (var part in parts)
            {
                if (newWord)
                {
                    if (part.StartsWith("\""))
                    {
                        if (part.EndsWith("\""))
                        {
                            blocks.Add(part.Trim('"'));
                        }
                        else
                        {
                            blocks.Add(part);
                            newWord = false;
                        }
                    }
                    else
                    {
                        blocks.Add(part);
                    }
                }
                else
                {
                    blocks[^1] += (" " + part);
                    if (part.EndsWith("\""))
                    {
                        newWord = true;
                        blocks[^1] = blocks[^1].Trim('"');
                    }
                }
            }
            if (!newWord)
            {
                return (null, $"Unmatched quotes. Make sure parameters are separated by spaces.");
            }
            if (blocks.Count < 2 || blocks.Count > 3)
            {
                return (null, $"The line contains {blocks.Count} individual parameters, expected only 2 or 3.");
            }
            return CheckArgs(blocks);
        }

        private static (InputEntry?, string?) CheckArgs(IList<string> args)
        {
            int backupLevel = 0;
            if (args.Count == 3 && !int.TryParse(args[2], out backupLevel))
            {
                return (null, $"Unable to parse backup level [{args[2]}]. It should be an integer 0 - 9.");
            }
            if (backupLevel < 0 || backupLevel > 9)
            {
                return (null, $"Backup level is wrong: [{args[2]}]. It should be an integer 0 - 9.");
            }
            if (!Directory.Exists(args[0]))
            {
                return (null, $"Source folder does not exist: [{args[0]}]. It should be an existing accessible file system directory.");
            }
            if (!Directory.Exists(args[1]))
            {
                return (null, $"Destination folder does not exist: [{args[1]}]. It should be an existing accessible file system directory.");
            }
            return (new InputEntry(args[0], args[1], backupLevel), null);
        }

        public (IProgress, Thread) KickOff(MMLogger logger)
        {
            if (Error != null || Mode == RunMode.Gui)
            {
                throw new InvalidOperationException("Auto kick-off only possible when no Error parsed and Mode is Default or Batch");
            }
            if (Mode == RunMode.Default)
            {
                return Run(() => new Session(logger), (s) => s.Run(Entries[0]));
            }
            else
            {
                return Run(() => new SessionBatch(), (s) => s.Run(logger, Entries));
            }
        }

        public (IProgress, Thread) KickOff() => KickOff(Shared.GetDefaultFileLogger());

        private static (IProgress, Thread) Run<T>(Func<T> ctor, Action<T> task) where T : IProgress
        {
            T progressMeter = ctor();
            var runThread = new Thread(() => task(progressMeter));
            runThread.Start();
            return (progressMeter, runThread);
        }
    }
}
