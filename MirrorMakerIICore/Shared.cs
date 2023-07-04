using MirrorMakerIICore.Infra;
using System.Reflection;

namespace MirrorMakerIICore
{
    public static class Shared
    {
        public const string BackupFormat = "$mm$bckp$";
        private const string DefaultLogFileName = "MMII.log";

        public static string Rebase(string path, string pathRoot, string newRoot)
        {
            return newRoot + path.Substring(pathRoot.Length);
            //return string.Concat(newRoot, path.AsSpan(pathRoot.Length));
        }

        public static MMLogger GetDefaultFileLogger() => new(DefaultLogFileName);

        public static InputParameters ParseArguments(string[] args) => new(args);

        public static LogDataFile ParseDefaultLogFile() => new(DefaultLogFileName);

        public static string Version => $" v.{Assembly.GetEntryAssembly()?.GetName()?.Version}";
    }

    public enum RunMode
    {
        Default, Batch, Gui
    }
}
