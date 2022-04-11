using MirrorMakerII;

//string source = @"D:\hackd",
//       destination = @"Z:\Backup\Mike";
string source = @"D:\hackd\Pix",
       destination = @"C:\Temp";
int    backupLevel = 1;


InputEntry entry = new(source, destination, backupLevel);
MMLogger l = new("MMII.log");
var session = new Session(l);
var runThread = new Thread(() => session.Run(entry));
runThread.Start();
while (session.Progress < 1.0)
{
    Console.WriteLine($"{session.Progress * 100:F2}% {session.Current}");
}

