using ScannerCore;

string source = @"D:\hackd",
       destination = @"Z:\Backup\Mike";

var runners = new List<Thread>();
FsItem fsSrc = null, fsDst = null;
DriveScanner scSrc = new DriveScanner(), scDst = new DriveScanner();
Thread thSrc = new Thread(() => fsSrc = scSrc.ScanDirectory(source)), thDst = new Thread(() => fsDst = scDst.ScanDirectory(destination));

runners.Add(thSrc);
runners.Add(thDst);
runners.ForEach(runner => runner.Start());
while (runners.Any(r => r.IsAlive))
{
    Console.WriteLine($"S => {(thSrc.IsAlive ? scSrc.CurrentScanned : "completed.")}");
    Console.WriteLine($"D => {(thDst.IsAlive ? scDst.CurrentScanned : "completed.")}");
    Thread.Sleep(100);
}
//runners.ForEach(runner => runner.Join());

Compare(fsSrc, fsDst);
Console.WriteLine("Complete.");
Console.ReadKey();

static void Compare(FsItem source, FsItem destination)
{
    for (int s = source.Items.Count - 1; s >= 0; s--)
    {
        var sItem = source.Items[s];
        int d = destination.Items.Count;
        if (d > 0)
        {
            FsItem dItem;
            do
            {
                d--;
                dItem = d >= 0 ? destination.Items[d] : null;
            } while (dItem != null && (dItem.Name != sItem.Name || dItem.IsDir != sItem.IsDir));
            if (dItem != null) //matched
            {
                if (sItem.IsDir)
                {
                    Compare(sItem, dItem);
                    if (sItem.Items.Count == 0) source.Items.RemoveAt(s);
                    if (dItem.Items.Count == 0) destination.Items.RemoveAt(d);
                }
                else if (sItem.LastModified == dItem.LastModified && sItem.Size == dItem.Size)
                {
                    source.Items.RemoveAt(s);
                    destination.Items.RemoveAt(d);
                }
            }
        }
    }
}

