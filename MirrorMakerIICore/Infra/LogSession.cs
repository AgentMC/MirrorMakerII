using ErrorableSource = System.ValueTuple<string, string?>;
using ErrorableSourceDestination = System.ValueTuple<string, string, string?>;

namespace MirrorMakerIICore.Infra
{
    public class LogSession
    {
        public readonly DateTime Start;
        public DateTime End;
        public readonly string From, To, Backup;
        public readonly List<ErrorableSource> BackupDirectoryDelete;
        public readonly List<ErrorableSourceDestination> BackupDirectoryMove;
        public readonly List<ErrorableSource> BackupDirectoryCreate;
        public readonly List<ErrorableSource> MirrorDirectoryCreate;
        public readonly List<ErrorableSource> MirrorFileDelete;
        public readonly List<ErrorableSourceDestination> BackupFileMove;
        public readonly List<ErrorableSourceDestination> MirrorFileMove;
        public readonly List<ErrorableSourceDestination> MirrorFileCopy;
        public readonly List<ErrorableSource> MirrorDirectoryDelete;

        public TimeSpan Duration => End - Start;

        public LogSession(LogEntry startEntry)
        {
            if (startEntry.EntryType != LogType.STA) throw new Exception("Missing Starting entry");
            Start = startEntry.Timestamp;
            End = Start;
            From = startEntry.Tags[0];
            To = startEntry.Tags[1];
            Backup = startEntry.Tags[2];
            BackupDirectoryDelete = new List<ErrorableSource>();
            BackupDirectoryMove = new List<ErrorableSourceDestination>();
            BackupDirectoryCreate = new List<ErrorableSource>();
            MirrorDirectoryCreate = new List<ErrorableSource>();
            MirrorFileDelete = new List<ErrorableSource>();
            BackupFileMove = new List<ErrorableSourceDestination>();
            MirrorFileMove = new List<ErrorableSourceDestination>();
            MirrorFileCopy = new List<ErrorableSourceDestination>();
            MirrorDirectoryDelete = new List<ErrorableSource>();
        }

        public void Append(LogEntry entry)
        {
            End = entry.Timestamp;
            switch (entry.EntryType)
            {
                case LogType.BDC:
                    BackupDirectoryCreate.Add(new ErrorableSource(entry.Tags[0], null));
                    break;
                case LogType.MDC:
                    MirrorDirectoryCreate.Add(new ErrorableSource(entry.Tags[0], null));
                    break;
                case LogType.EDC:
                    MirrorDirectoryCreate.Add(new ErrorableSource(entry.Tags[0], entry.Tags[1]));
                    break;
                case LogType.BFM:
                    BackupFileMove.Add(new ErrorableSourceDestination(entry.Tags[0], entry.Tags[1], null));
                    break;
                case LogType.MFM:
                    MirrorFileMove.Add(new ErrorableSourceDestination(entry.Tags[0], entry.Tags[1], null));
                    break;
                case LogType.EFM:
                    MirrorFileMove.Add(new ErrorableSourceDestination(entry.Tags[0], entry.Tags[1], entry.Tags[2]));
                    break;
                case LogType.MFC:
                    MirrorFileCopy.Add(new ErrorableSourceDestination(entry.Tags[0], entry.Tags[1], null));
                    break;
                case LogType.EFC:
                    MirrorFileCopy.Add(new ErrorableSourceDestination(entry.Tags[0], entry.Tags[1], entry.Tags[2]));
                    break;
                case LogType.MFD:
                    MirrorFileDelete.Add(new ErrorableSource(entry.Tags[0], null));
                    break;
                case LogType.EFD:
                    MirrorFileDelete.Add(new ErrorableSource(entry.Tags[0], entry.Tags[1]));
                    break;
                case LogType.BDD:
                    BackupDirectoryDelete.Add(new ErrorableSource(entry.Tags[0], null));
                    break;
                case LogType.MDD:
                    MirrorDirectoryDelete.Add(new ErrorableSource(entry.Tags[0], null));
                    break;
                case LogType.EDD:
                    MirrorDirectoryDelete.Add(new ErrorableSource(entry.Tags[0], entry.Tags[1]));
                    break;
                case LogType.BDM:
                    BackupDirectoryMove.Add(new ErrorableSourceDestination(entry.Tags[0], entry.Tags[1], null));
                    break;
                case LogType.EDM:
                    BackupDirectoryMove.Add(new ErrorableSourceDestination(entry.Tags[0], entry.Tags[1], entry.Tags[2]));
                    break;
                default:
                    break;
            }

        }

        public override string ToString()
        {
            return $"{Start} {From} => {To} ({Backup}) : {(Duration.Ticks == 0 ? "Unfinished" : Duration)}";
        }
    }
}
