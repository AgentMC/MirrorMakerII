using MirrorMakerIICore;
using MirrorMakerIICore.Infra;

namespace WinMirrorMakerII
{
    public partial class LogParser : Form
    {
        private readonly LogDataFile _logfile;
        public LogParser()
        {
            InitializeComponent();

            _logfile = Shared.ParseDefaultLogFile();
            SessionsDropDown.DataSource = _logfile.Sessions;
            SessionsDropDown.SelectedItem = _logfile.Sessions[^1];
        }

        private void SessionsDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SessionsDropDown.SelectedItem is LogSession session)
            {
                BackupDirectoryDeleteList.DataSource = session.BackupDirectoryDelete;
                BackupDirectoryMoveList.DataSource = session.BackupDirectoryMove;
                BackupDirectoryCreateList.DataSource = session.BackupDirectoryCreate;
                BackupFileMoveList.DataSource = session.BackupFileMove;
                MirrorDirectoryCreateList.DataSource = session.MirrorDirectoryCreate;
                MirrorDirectoryDeleteList.DataSource = session.MirrorDirectoryDelete;
                MirrorFileDeleteList.DataSource = session.MirrorFileDelete;
                MirrorFileMoveList.DataSource = session.MirrorFileMove;
                MirrorFileCopyList.DataSource = session.MirrorFileCopy;
                BackupDirectoryDeleteList.SelectedIndex = -1;
                BackupDirectoryMoveList.SelectedIndex = -1;
                BackupDirectoryCreateList.SelectedIndex = -1;
                BackupFileMoveList.SelectedIndex = -1;
                MirrorDirectoryCreateList.SelectedIndex = -1;
                MirrorDirectoryDeleteList.SelectedIndex = -1;
                MirrorFileDeleteList.SelectedIndex = -1;
                MirrorFileMoveList.SelectedIndex = -1;
                MirrorFileCopyList.SelectedIndex = -1;
            }
            else
            {
                BackupDirectoryDeleteList.DataSource = null;
                BackupDirectoryMoveList.DataSource = null;
                BackupDirectoryCreateList.DataSource = null;
                BackupFileMoveList.DataSource = null;
                MirrorDirectoryCreateList.DataSource = null;
                MirrorDirectoryDeleteList.DataSource = null;
                MirrorFileDeleteList.DataSource = null;
                MirrorFileMoveList.DataSource = null;
                MirrorFileCopyList.DataSource = null;
            }
        }

        private static readonly Dictionary<string, Color> fileMarkers = new()
        {
            {".avi", Color.Orange },
            {".mkv", Color.Orange },
            {".mov", Color.Orange },
            {".rmv", Color.Orange },
            {".rm",  Color.Orange },
            {".wmv", Color.Orange },
            {".mp4", Color.Orange },
            {".ts",  Color.Orange },
            {".vob", Color.Orange },
            {".mp3", Color.Pink },
            {".ogg", Color.Pink },
            {".wma", Color.Pink },
            {".rma", Color.Pink },
            {".fla", Color.Pink },
            {".flac",Color.Pink },
            {".wav", Color.Pink },
            {".rar", Color.LightGreen },
            {".zip", Color.LightGreen },
            {".7z",  Color.LightGreen },
            {".tgz", Color.LightGreen },
            {".z",   Color.LightGreen },
            {".exe", Color.Yellow },
            {".com", Color.Yellow },
            {".dll", Color.Yellow },
            {".msi", Color.Yellow },
            {".jpg", Color.SkyBlue },
            {".g",   Color.SkyBlue },
            {".png", Color.SkyBlue },
            {".tga", Color.SkyBlue },
            {".t",   Color.SkyBlue },
            {".tf",  Color.SkyBlue },
            {".psd", Color.SkyBlue },
        };

        private void Renderer(object sender, DrawItemEventArgs e)
        {
            if (e.Index >= 0)
            {
                var lb = (ListBox)sender;
                var item = lb.Items[e.Index];
                string? from = null, to = null, error = null;
                if (item is Tuple<string, string?> tuple2)
                {
                    from = tuple2.Item1;
                    error = tuple2.Item2;
                }
                else if (item is Tuple<string, string, string?> tuple3)
                {
                    from = tuple3.Item1;
                    to = tuple3.Item2;
                    error = tuple3.Item3;
                }
                if (from != null)
                {
                    Color background;
                    Brush foreground;
                    var text = to != null ? $"{from} => {to}" : from;
                    if (error != null)
                    {
                        text = $"ERROR {text} : {error}";
                        background = e.BackColor;
                        foreground = Brushes.Red;
                    }
                    else
                    {
                        foreground = Brushes.Black;
                        var key = Path.GetExtension(from);
                        if (string.IsNullOrEmpty(key) || !fileMarkers.TryGetValue(key.ToLower(), out background))
                        {
                            background = e.BackColor;
                        }
                    }
                    e.Graphics.SetClip(e.Bounds);
                    e.Graphics.Clear(background);
                    e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
                    e.Graphics.DrawString(text, e.Font ?? lb.Font, foreground, e.Bounds, new StringFormat { Alignment = StringAlignment.Near, FormatFlags = StringFormatFlags.FitBlackBox | StringFormatFlags.NoWrap | StringFormatFlags.NoClip, Trimming = StringTrimming.None, LineAlignment = StringAlignment.Far});
                    if (e.Index == lb.SelectedIndex) e.DrawFocusRectangle();
                }
                else
                {
                    e.DrawBackground();
                }
            }
            else
            {
                e.DrawBackground();
            }
        }
    }
}
