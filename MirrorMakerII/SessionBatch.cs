namespace MirrorMakerII
{
    internal class SessionBatch : IProgress
    {
        private IProgress? _current;
        private int _totalComplete, _total;

        public void Run(MMLogger logger, IReadOnlyCollection<InputEntry> entries)
        {
            _total = entries.Count;
            foreach (var input in entries)
            {
                var session = new Session(logger);
                _current = session;
                session.Run(input);
                _totalComplete++;
                _current = null;
            }
        }

        public double Progress => (_totalComplete + (_current?.Progress ?? 0)) / _total;

        public string Current => $"{Math.Min(_total, _totalComplete + 1)} / {_total}: {_current?.Current ?? "(>>>)"}";
    }
}
