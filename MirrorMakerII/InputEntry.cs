namespace MirrorMakerII
{
    internal class InputEntry
    {
        public readonly string Source, Destination;
        public readonly int BackupLevel;

        public InputEntry (string source, string destination, int backupLevel = 0)
        {
            Source = source;    
            Destination = destination;  
            BackupLevel = backupLevel;
        }
    }
}
