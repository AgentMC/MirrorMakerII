using MirrorMakerIICore.Infra;

namespace MirrorMakerIICore
{
    public class SessionBatch : IProgress
    {
        private IProgress? _current;
        private int _totalComplete, _total;

        public void Run(MMLogger logger, IReadOnlyCollection<InputEntry> entries)
        {
            _total = entries.Count;
            foreach (var input in entries)
            {
                if (logger.Token.IsCancellationRequested) break;
                CurrentEntryChanged?.Invoke(this, new CurrentEntryEventArgs(input));
                var session = new Session(logger);
                _current = session;
                session.Run(input);
                _totalComplete++;
                _current = null;
            }
            CurrentEntryChanged?.Invoke(this, new CurrentEntryEventArgs(null));
        }

        public void Cancel()
        {
            _current?.Cancel();
        }

        public double Progress => (_totalComplete + (_current?.Progress ?? 0)) / _total;

        public string Current => $"{Math.Min(_total, _totalComplete + 1)} / {_total}: {_current?.Current ?? "(>>>)"}";

        public double CurrentEntryProgress => _current?.Progress ?? 0;

        public event EventHandler<CurrentEntryEventArgs>? CurrentEntryChanged;
    }

    public class CurrentEntryEventArgs: EventArgs
    {
        public InputEntry? Entry { get; private set; }

        public CurrentEntryEventArgs(InputEntry? entry)
        {
            Entry = entry;
        }
    }
}
