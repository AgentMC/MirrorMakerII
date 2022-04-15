using MirrorMakerII;
using System.Text;

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
        Run(() => new Session(l), (s) => s.Run(parameters.Entries[0]));
        break;
    case RunMode.Batch:
        Run(() => new SessionBatch(), (s) => s.Run(l, parameters.Entries));
        break;
    case RunMode.Gui:
        Console.WriteLine("Launch in GUI mode (parameterless) not supported by console version.\r\nUse MMII.exe /? to get invokation help.");
        break;
    default:
        break;
}

void Run<T>(Func<T> ctor, Action<T> task) where T : IProgress
{
    T progressMeter = ctor();
    var runThread = new Thread(() => task(progressMeter));
    runThread.Start();

    var builder = new StringBuilder();
    var (left, top) = Console.GetCursorPosition();
    int lastTextLength = 0;
    while (progressMeter.Progress < 1.0)
    {
        builder.Clear();
        builder.Append($"{progressMeter.Progress * 100:F2}% {progressMeter.Current}");
        var newTextLength = builder.Length;
        builder.Append(' ', Math.Max(0, lastTextLength - builder.Length));
        lastTextLength = newTextLength;
        Console.SetCursorPosition(left, top);
        Console.Write(builder.ToString());
        Thread.Sleep(300);
    }
    Console.WriteLine("\r\nComplete.");
}
