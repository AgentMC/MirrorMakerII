using MirrorMakerIICore;
using MirrorMakerIICore.Infra;

namespace WinMirrorMakerII
{
    public partial class SessionWindow: Form
    {
        public SessionWindow()
        {
            InitializeComponent();
            Text += Shared.Version;
            ShowLog.Enabled = Shared.DefaultLogFileExists;
        }

        private IProgress? _operationProgress;
        private SessionBatch? _batchRunner;
        private bool _closeOnSessionComplete = true;


        public SessionWindow(InputParameters parameters): this()
        {
            //Gui or Default - hide batch section
            if (parameters.Mode != RunMode.Batch)
            {
                Height -= BatchPanel.Height;
                BatchPanel.Height = 0;
            }
            else //Batch - populate batch list
            {
                foreach (var entry in parameters.Entries)
                {
                    BatchList.Items.Add(entry);
                }
                BatchList.SelectedIndex = 0;
            }

            //auto-run - initialize fields, kickoff operation, register for batch/session updates, hide window, disable controls
            if (parameters.Mode != RunMode.Gui)
            {
                WindowState = FormWindowState.Minimized;
                Begin(parameters);
            }
        }

        private void Begin(InputParameters parameters)
        {
            SetUiEnabledState(false);
            UpdateFieldsInAutoMode(parameters.Entries[0]);

            (_operationProgress, _) = parameters.KickOff();
            _batchRunner = _operationProgress as SessionBatch;
            if (_batchRunner != null)
            {
                _batchRunner.CurrentEntryChanged += BatchCurrentEntryChanged;
            }
            MonitorTimer.Start();
        }

        private void SetUiEnabledState(bool state)
        {
            SourceButon.Enabled = state;
            DestinationButton.Enabled = state;
            BackupLevelSelector.Enabled = state;
            ManualRun.Enabled = state;
            ShowLog.Enabled = state;
            Cancel.Enabled = !state;
            API.TaskbarManager.SetState(Handle, state ? API.TaskbarManager.TaskbarStates.NoProgress : API.TaskbarManager.TaskbarStates.Normal);
            API.TaskbarManager.SetValue(Handle, 0, 100);
        }

        private void BatchCurrentEntryChanged(object? sender, CurrentEntryEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(() => BatchCurrentEntryChanged(sender, e));
                return;
            }
            if(e.Entry == null) //game over
            {
                MonitorTimer.Stop();
                Close();
                return;
            }
            UpdateFieldsInAutoMode(e.Entry); //update fields
            if(e.Entry != BatchList.SelectedItem)
            {
                BatchList.SelectedIndex++;
            }
        }

        private void UpdateFieldsInAutoMode(InputEntry input)
        {
            SourceBox.Text = input.Source;
            DestinationBox.Text = input.Destination;
            BackupLevelSelector.Value = input.BackupLevel;
        }

        private void MonitorTimer_Tick(object sender, EventArgs e)
        {
            if(_operationProgress == null)
            {
                return;
            }
            if (_operationProgress.Progress == 1 && _batchRunner == null) //completed session in gui or single auto mode.
            {
                MonitorTimer.Stop();
                if (_closeOnSessionComplete) //single auto mode
                {
                    Close();
                    return;
                }
                else //manual
                {
                    SetUiEnabledState(true);
                }
            }
            Status.Text = _operationProgress.Current;
            var totalProgress = (int)(_operationProgress.Progress * 100);
            API.TaskbarManager.SetValue(Handle, (UInt64)totalProgress, 100);
            if(_batchRunner != null) //Batch mode
            {
                TotalProgress.Value = totalProgress;
                SessionProgress.Value = (int)(_batchRunner.CurrentEntryProgress * 100);
            }
            else //Gui or Default
            {
                SessionProgress.Value = totalProgress;
            }
        }

        private void GuiRun(object sender, EventArgs e)
        {
            _closeOnSessionComplete = false;
            Begin(new InputParameters(SourceBox.Text, DestinationBox.Text, (int)BackupLevelSelector.Value));
        }

        private void PathLoad(object sender, EventArgs e)
        {
            var select = folderLoader.ShowDialog();
            if(select == DialogResult.OK)
            {
                (sender == SourceButon? SourceBox : DestinationBox).Text = folderLoader.SelectedPath;
                ManualRun.Enabled = (!string.IsNullOrEmpty(SourceBox.Text) && !string.IsNullOrEmpty(DestinationBox.Text));
            }
        }

        private void ShowLog_Click(object sender, EventArgs e)
        {
            new LogParser().ShowDialog();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            _operationProgress?.Cancel();
        }
    }
}