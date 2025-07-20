using System.Collections;

namespace MirrorMakerIICore.Infra
{
    public class LogEntry
    {
        private class LogMapper : IReadOnlyList<string>
        {
            private readonly string source;
            private List<ValueTuple<int, int>>? pointers;

            public LogMapper(string source)
            {
                this.source = source;
            }

            public void Add(int start, int end)
            {
                if (pointers == null) pointers = new List<ValueTuple<int, int>>();
                pointers.Add(ValueTuple.Create(start, end));
            }

            public string this[int index]
            {
                get
                {
                    if (pointers == null) return string.Empty;
                    var t = pointers[index];
                    return source[t.Item1..t.Item2];
                }
            }

            public int Count => pointers?.Count ?? 0;

            public IEnumerator<string> GetEnumerator()
            {
                return new SimpleEnumerator(this);
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            private class SimpleEnumerator : IEnumerator<string>
            {
                private readonly LogMapper mapper;
                private int index = -1;

                public SimpleEnumerator(LogMapper mapper)
                {
                    this.mapper = mapper;
                }

                public string Current => mapper[index];

                object IEnumerator.Current => Current;

                public void Dispose() { }

                public bool MoveNext()
                {
                    return ++index < mapper.Count;
                }

                public void Reset()
                {
                    index = -1;
                }
            }
        }

        public readonly DateTime Timestamp;
        public readonly LogType EntryType;
        public readonly string Message;
        public readonly IReadOnlyList<string> Tags;

        public LogEntry(string logLine)
        {
            var coreTokens = logLine.Split('\t');
            Timestamp = DateTime.ParseExact(coreTokens[0], "O", null);
            EntryType = Enum.Parse<LogType>(coreTokens[1]);
            Message = coreTokens[2];
            var mapper = new LogMapper(Message);
            Tags = mapper;

            int open = -1, level = -1;
            for (int i = 0; i < Message.Length; i++)
            {
                switch (Message[i])
                {
                    case '[':
                        level++;
                        if (level == 0) open = i;
                        break;
                    case ']':
                        if (open != -1 && level == 0) mapper.Add(++open, i);
                        level--;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
