using ScannerCore;
#pragma warning disable 8604, 8602, 8600, 8619

namespace MirrorMakerII
{
    internal class Scanner
    {
        public static (FsItem, FsItem) Scan (string source, string destination, MMLogger l)
        {
            var scanners = new List<Thread>();
            //File System Tree objects
            FsItem fsSrc = null,
                   fsDst = null;
            //Scanner objects
            DriveScanner scSrc = new(),
                         scDst = new();
            //Threads
            Thread thSrc = new(() => fsSrc = scSrc.ScanDirectory(source)),
                   thDst = new(() => fsDst = scDst.ScanDirectory(destination));

            //Scan
            scanners.Add(thSrc);
            scanners.Add(thDst);
            scanners.ForEach(scanner => scanner.Start());
#if DEBUG
            while (scanners.Any(r => r.IsAlive))
            {
                Console.WriteLine($"S => {(thSrc.IsAlive ? scSrc.CurrentScanned : "completed.")}");
                Console.WriteLine($"D => {(thDst.IsAlive ? scDst.CurrentScanned : "completed.")}");
                Thread.Sleep(100);
            }
#else
            runners.ForEach(runner => runner.Join());
#endif
            l.Basic("Tree building complete.");
            return (fsSrc, fsDst);
        }
    }
}
