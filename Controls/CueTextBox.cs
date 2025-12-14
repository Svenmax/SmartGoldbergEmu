// Thanks, Credits to Hans Passant:
// https://stackoverflow.com/questions/4902565/watermark-textbox-in-winforms

using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing;
using OSUtility;

class CueTextBox : TextBox
{
    private const int EM_SETCUEBANNER = 0x1501;
    private const int EM_GETCUEBANNER = 0x1502;

    [Localizable(true)]
    public string Cue
    {
        get { return mCue; }
        set { mCue = value; UpdateCue(); }
    }

    private void UpdateCue()
    {
        if (this.IsHandleCreated && mCue != null)
        {
            if (OSDetector.IsWindows())
            {
                // Use system colors for normal appearance
                this.BackColor = SystemColors.Window;
                this.ForeColor = SystemColors.WindowText;
                SendMessage(this.Handle, EM_SETCUEBANNER, (IntPtr)1, mCue);
            }
            else
            {
                // For non-Windows platforms, implement custom placeholder
                if (string.IsNullOrEmpty(this.Text))
                {
                    this.Text = mCue;
                    this.ForeColor = SystemColors.GrayText;
                }
            }
        }
    }

    protected override void OnHandleCreated(EventArgs e)
    {
        base.OnHandleCreated(e);
        UpdateCue();
        if(!OSDetector.IsWindows())
        {
            this.GotFocus += (Object sender, EventArgs ev) =>
            {
                if(Text == mCue)
                {
                    Text = "";
                    this.ForeColor = SystemColors.WindowText;
                }
            };

            this.LostFocus += (Object sender, EventArgs ev) =>
            {
                if(Text == "")
                {
                    Text = mCue;
                    this.ForeColor = Color.FromArgb(200, 200, 200);
                }
            };
        }
    }

    private string mCue;

    // PInvoke
    [DllImport("user32.dll", CharSet = CharSet.Unicode)]
    private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, string lp);
}