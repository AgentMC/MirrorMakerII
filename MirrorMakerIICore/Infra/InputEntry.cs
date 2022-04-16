namespace MirrorMakerIICore.Infra
{
    public class InputEntry
    {
        public readonly string Source, Destination;
        public readonly int BackupLevel;

        public InputEntry (string source, string destination, int backupLevel = 0)
        {
            Source = Path.TrimEndingDirectorySeparator(source);
            Destination = Path.TrimEndingDirectorySeparator(destination);
            BackupLevel = backupLevel;
        }
    }
}
