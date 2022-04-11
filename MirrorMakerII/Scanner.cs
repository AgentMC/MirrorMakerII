using ScannerCore;
#pragma warning disable 8604, 8602, 8600, 8619

namespace MirrorMakerII
{
    internal class Scanner:IProgress
    {
        private volatile int _done = 0;
        private volatile string? _current = "(initialization)";

        public double Progress => _done / 2.0;

        public string Current => $"Scanning: {_current}";

        public (FsItem, FsItem) Scan (string source, string destination, MMLogger l)
        {
            var scanners = new List<Thread>();
            //File System Tree objects
            FsItem fsSrc = null,
                   fsDst = null;
            //Scanner objects
            DriveScanner scSrc = new(),
                         scDst = new();
            //Threads
            Thread thSrc = new(() => fsSrc = RunInternal(source, scSrc)),
                   thDst = new(() => fsDst = RunInternal(destination, scDst));

            //Scan
            scanners.Add(thSrc);
            scanners.Add(thDst);
            scanners.ForEach(scanner => scanner.Start());

            while (_done < 2)
            {
                _current = thSrc.IsAlive ? scSrc.CurrentScanned : thDst.IsAlive ? scDst.CurrentScanned : "(completed)";
                Thread.Sleep(10);
            }
            l.Basic("Tree building complete.");
            return (fsSrc, fsDst);
        }

        private FsItem RunInternal(string path, DriveScanner scanner)
        {
            var result = scanner.ScanDirectory(path);
            Interlocked.Increment(ref _done);
            return result;
        }
    }
}
