using System;
using System.Windows.Forms;
using System.Timers;

namespace SmartGoldbergEmu.Helpers
{
    public class FeedbackReporter
    {
        private readonly ToolStripProgressBar _progressBar;
        private readonly ToolStripStatusLabel _statusLabel;
        private readonly Control _invoker;
        private System.Timers.Timer _clearTimer;
        private const int ClearDelayMs = 10000; // 10 seconds

        public FeedbackReporter(ToolStripProgressBar progressBar, ToolStripStatusLabel statusLabel, Control invoker)
        {
            _progressBar = progressBar;
            _statusLabel = statusLabel;
            _invoker = invoker;
            _clearTimer = new System.Timers.Timer(ClearDelayMs);
            _clearTimer.AutoReset = false;
            _clearTimer.Elapsed += (s, e) =>
            {
                if (_statusLabel == null) return;
                if (_invoker.InvokeRequired)
                {
                    _invoker.Invoke(new Action(() => SetMessage("")));
                }
                else
                {
                    SetMessage("");
                }
            };
        }

        public void SetProgress(int value, int max = 100)
        {
            if (_progressBar == null) return;
            if (_invoker.InvokeRequired)
            {
                _invoker.Invoke(new Action(() => SetProgress(value, max)));
                return;
            }
            _progressBar.Maximum = max;
            _progressBar.Value = Math.Min(Math.Max(value, 0), max);
        }

        public void SetMessage(string message)
        {
            if (_statusLabel == null) return;
            if (_invoker.InvokeRequired)
            {
                _invoker.Invoke(new Action(() => SetMessage(message)));
                return;
            }
            _statusLabel.Text = message;
            _clearTimer.Stop();
            if (!string.IsNullOrEmpty(message))
            {
                _clearTimer.Interval = ClearDelayMs;
                _clearTimer.Start();
            }
        }

        public void ClearMessage()
        {
            if (_statusLabel == null) return;
            if (_invoker.InvokeRequired)
            {
                _invoker.Invoke(new Action(ClearMessage));
                return;
            }
            _statusLabel.Text = "";
            _clearTimer.Stop();
        }

        public void Reset()
        {
            SetProgress(0);
            SetMessage("");
        }
    }
} 