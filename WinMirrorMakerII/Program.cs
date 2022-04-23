using MirrorMakerIICore;

namespace WinMirrorMakerII
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            var parameters = Shared.ParseArguments(args);

            if (parameters.Error != null)
            {
                MessageBox.Show(parameters.Error, "MirrorMaker II - error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Application.Run(new SessionWindow(parameters));
        }
    }
}