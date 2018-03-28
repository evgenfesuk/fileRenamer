using System;
using System.Windows.Forms;

namespace Logic
{
    public static class PBar
    {
        public static void Init(ProgressBar pBar, int maxValue)
        {
            pBar.Value = 0;
            pBar.Maximum = maxValue;
        }

        public static void Init(System.Windows.Controls.ProgressBar pBar, int maxValue)
        {
            if (pBar == null) throw new ArgumentNullException(nameof(pBar));
            pBar.Value = 0;
            pBar.Maximum = maxValue;
        }

        public static void Run(ProgressBar pBar, int filesCount, Label lblTotalFiles, int filesDone)
        {
            if (pBar == null) throw new ArgumentNullException(nameof(pBar));
            if (pBar.Value < filesCount) pBar.Value++;
            Application.DoEvents();
            lblTotalFiles.Text = filesDone.ToString();
        }

        public static void Run(System.Windows.Controls.ProgressBar pBar, int filesCount, System.Windows.Controls.Label lblTotalFiles, int filesDone)
        {
            if (pBar == null) throw new ArgumentNullException(nameof(pBar));
            if (lblTotalFiles == null) throw new ArgumentNullException(nameof(lblTotalFiles));
            if (pBar.Value < filesCount) pBar.Value++;
            Application.DoEvents();
            lblTotalFiles.Content = filesDone.ToString();
        }
    }
}
