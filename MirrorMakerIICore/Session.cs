using MirrorMakerIICore.Infra;

namespace MirrorMakerIICore
{
    public class Session : IProgress
    {
        public double Progress => 0.25 * _scanner.Progress + 0.05 * _comparer.Progress + 0.7 * _runner.Progress;

        public string Current => $"{_current.Item2} {_current.Item1?.Current ?? string.Empty}";

        private readonly Scanner _scanner;
        private readonly Comparer _comparer;
        private readonly OperationRunner _runner;
        private readonly MMLogger _logger;

        private (IProgress?, string) _current = (null, "Initializing.");

        public Session(MMLogger logger)
        {
            _scanner = new Scanner();
            _comparer = new Comparer();
            _runner = new OperationRunner(logger);
            _logger = logger;
        }

        public void Run(InputEntry inputEntry)
        {
            _logger.Start(inputEntry.Source, inputEntry.Destination, inputEntry.BackupLevel);

            _current = (_scanner, "Scanning: ");
            (var fsSrc, var fsDst) = _scanner.Scan(inputEntry.Source, inputEntry.Destination, _logger);

            _current = (_comparer, "Comparing: ");
            (var operation, var backupFolders) = _comparer.Compare(fsSrc, fsDst, _logger);

            _current = (_runner, "Running: ");
            _runner.Run(operation, backupFolders, inputEntry.BackupLevel, inputEntry.Destination);
        }
    }
}
