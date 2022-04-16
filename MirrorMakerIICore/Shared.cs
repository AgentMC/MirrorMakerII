using MirrorMakerIICore.Infra;

namespace MirrorMakerIICore
{
    public static class Shared
    {
        public const string BackupFormat = "$mm$bckp$";
        public static string Rebase(string path, string pathRoot, string newRoot)
        {
            return newRoot + path.Substring(pathRoot.Length);
            //return string.Concat(newRoot, path.AsSpan(pathRoot.Length));
        }

        public static MMLogger GetDefaultFileLogger() => new("MMII.log");

        public static InputParameters ParseArguments(string[] args) => new(args);
    }
}
