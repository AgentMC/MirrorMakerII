using System.Text;

namespace MirrorMakerII
{
    internal class MMLogger : IDisposable
    {
        readonly TextWriter _stream;
        readonly Encoding _encoding = Encoding.UTF8;
        readonly char[] Separators = new[] { '[', ']' };
        readonly bool _disposable;
        bool _disposed;

        internal MMLogger(string? filePath)
        {
            switch (filePath)
            {
                case null:
                    _stream = Console.Out;
                    _disposable = false;
                    break;
                case "":
                    throw new ArgumentNullException(nameof(filePath));
                default:
                    _stream = new StreamWriter(filePath, true, _encoding) { AutoFlush = true };
                    _disposable = true;
                    break;
            }
        }

        ~MMLogger() 
        {
            Dispose();
        }

        public void Dispose()
        {
            lock (this)
            {
                if (_disposable && !_disposed)
                {
                    _stream.Dispose();
                    _disposed = true;
                }
                GC.SuppressFinalize(this);
            }
        }

        public IProgressEx? StatusReflector { get; set; }

        private enum LogType
        {
            GEN,
            STA,
            BDC,
            MDC,
            EDC,
            BFM,
            MFM,
            EFM,
            MFC,
            EFC,
            MFD,
            EFD,
            BDD,
            MDD,
            EDD,
            BDM,
            EDM
        }

        private void Log(LogType lt, string message)
        {
            _stream.WriteLine($"{DateTime.Now:O}\t{lt}\t{message}");
            if (StatusReflector != null) StatusReflector.SetCurrent(message);
        }

        private void Log(LogType lt, string format, params object[] args)
        {
            Log(lt, string.Format(format, args.Select(a => Separators[0] + a.ToString() + Separators[1]).ToArray()));
        }

        public void Basic(string message) => Log(LogType.GEN, message);
        public void Start(string source, string destination, int backupLevel) => Log(LogType.STA, "Begin mirroring {0} => {1} with backup level {2}.", source, destination, backupLevel);

        public void BackupFolderCreate(string folder) => Log(LogType.BDC, "Created backup path structure if not existed: {0}.", folder);
        public void MirrorFolderCreate(string folder) => Log(LogType.MDC, "Created directory structure if not existed: {0}.", folder);
        public void ErrorFolderCreate(string folder, Exception e) => Log(LogType.EDC, "Error creating directory structure: {0}. {1}", folder, e.Message);

        public void BackupFileMove(string source, string destination) => Log(LogType.BFM, "Saved deleted file: {0} to temporary location {1}.", source, destination);
        public void MirrorFileMove(string source, string destination) => Log(LogType.MFM, "Moved existing file: {0} => {1}.", source, destination);
        public void ErrorFileMove(string source, string destination, Exception e) => Log(LogType.EFM, "Error moving existing file: {0} => {1}. {2}", source, destination, e.Message);

        public void MirrorFileCopy(string source, string destination) => Log(LogType.MFC, "Copied new file: {0} => {1}.", source, destination);
        public void ErrorFileCopy(string source, string destination, Exception e) => Log(LogType.EFC, "Error copying new file: {0} => {1}. {2}", source, destination, e.Message);

        public void MirrorFileDelete(string file) => Log(LogType.MFD, "Deleted file: {0}.", file);
        public void ErrorFileDelete(string file, Exception e) => Log(LogType.EFD, "Error deleting file: {0}. {1}", file, e.Message);

        public void BackupFolderDelete(string folder) => Log(LogType.BDD, "Deleted backup folder: {0}.", folder);
        public void MirrorFolderDelete(string folder) => Log(LogType.MDD, "Deleted folder: {0}.", folder);
        public void ErrorFolderDelete(string folder, Exception e) => Log(LogType.EDD, "Error checking or deleting folder: {0}. {1}", folder, e.Message);

        public void BackupFolderMove(string source, string destination) => Log(LogType.BDM, "Moved backup folder: {0} => {1}.", source, destination);
        public void ErrorFolderMove(string source, string destination, Exception e) => Log(LogType.EDM, "Error moving backup folder: {0} => {1}. {2}", source, destination, e.Message);
    }
}
