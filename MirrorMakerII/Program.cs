using System.Text;
using MirrorMakerIICore;

var parameters = Shared.ParseArguments(args);

if(parameters.Error != null)
{
    Console.WriteLine(parameters.Error);
    return;
}

switch (parameters.Mode)
{
    case RunMode.AutoSingle:
    case RunMode.AutoBatch:
        var (operation, _) = parameters.KickOff();
        Monitor(operation);
        break;
    case RunMode.Gui:
        Console.WriteLine("Launch in GUI mode (parameterless) not supported by console version.\r\nUse MMII.exe /? to get invokation help.");
        break;
    default:
        break;
}

static void Monitor(IProgress progressMeter) 
{
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
