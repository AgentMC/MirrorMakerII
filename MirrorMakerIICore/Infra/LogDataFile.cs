namespace MirrorMakerIICore.Infra
{
    public class LogDataFile
    {
        public readonly IReadOnlyList<LogSession> Sessions;

        internal LogDataFile(string fileName)
        {
            var sessionList = new List<LogSession>();
            Sessions = sessionList;
            string? line;
            LogSession? session = null;
            using var reader = new StreamReader(fileName, MMLogger.DefaultLogEncoding);
            while ((line = reader.ReadLine()) != null)
            {
                var entry = new LogEntry(line);
                if (entry.EntryType == LogType.STA)
                {
                    session = new LogSession(entry);
                    sessionList.Add(session);
                }
                else if (session != null)
                {
                    session.Append(entry);
                }
            }
        }
    }
}
