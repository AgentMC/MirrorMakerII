using MirrorMakerII;

//string source = @"D:\hackd",
//       destination = @"Z:\Backup\Mike";

//string source = @"D:\hackd\Pix",
//       destination = @"C:\Temp";
//int    backupLevel = 1;
//InputEntry entry = new(source, destination, backupLevel);


MMLogger l = new("MMII.log");

var parameters = new InputParameters(args);
if(parameters.Error != null)
{
    Console.WriteLine(parameters.Error);
    return;
}
switch (parameters.Mode)
{
    case RunMode.Default:
        RunSession(parameters.Entries[0]);
        break;
    case RunMode.Batch:
        break;
    case RunMode.Gui:
        Console.WriteLine("Launch in GUI mode (parameterless) not supported by console version.\r\nUse MMII.exe /? to get invokation help.");
        break;
    default:
        break;
}

void RunSession(InputEntry entry)
{
    var session = new Session(l);
    var runThread = new Thread(() => session.Run(entry));
    runThread.Start();
    while (session.Progress < 1.0)
    {
        Console.WriteLine($"{session.Progress * 100:F2}% {session.Current}");
    }
}


