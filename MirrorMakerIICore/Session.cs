using MirrorMakerIICore.Infra;

namespace MirrorMakerIICore
{
    public class Session : IProgress
    {
        public double Progress => _logger.Token.IsCancellationRequested && _sessionComplete ? 1.0 : 0.25 * _scanner.Progress + 0.05 * _comparer.Progress + 0.7 * _runner.Progress;

        public string Current => $"{_current.Item2} {_current.Item1?.Current ?? string.Empty}";

        private readonly Scanner _scanner;
        private readonly Comparer _comparer;
        private readonly OperationRunner _runner;
        private readonly MMLogger _logger;

        private bool _sessionComplete;

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

            if (_logger.Token.IsCancellationRequested) goto end;
            _current = (_scanner, "Scanning: ");
            (var fsSrc, var fsDst) = _scanner.Scan(inputEntry.Source, inputEntry.Destination, _logger);

            if (_logger.Token.IsCancellationRequested) goto end;
            _current = (_comparer, "Comparing: ");
            (var operation, var backupFolders) = _comparer.Compare(fsSrc, fsDst, _logger);

            if (_logger.Token.IsCancellationRequested) goto end;
            _current = (_runner, "Running: ");
            _runner.Run(operation, backupFolders, inputEntry.BackupLevel, inputEntry.Destination);

        end:
            if (_logger.Token.IsCancellationRequested) _logger.Basic("Session was cancelled.");
            _sessionComplete = true;
        }

        public void Cancel()
        {
            _logger.TokenCancel();
        }
    }
}
