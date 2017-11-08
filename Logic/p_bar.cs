using System.Windows.Forms;

namespace Logic
{
    public static class p_bar
    {
        public static void Init(ProgressBar p_bar, int max_value)
        {
            p_bar.Value = 0;
            p_bar.Maximum = max_value;
        }

        public static void Init(System.Windows.Controls.ProgressBar p_bar, int max_value)
        {
            p_bar.Value = 0;
            p_bar.Maximum = max_value;
        }

        public static void Run(ProgressBar p_bar, int filesCount, Label lbl_totalFiles, int filesDone)
        {
            if (p_bar.Value < filesCount) p_bar.Value++;
            Application.DoEvents();
            lbl_totalFiles.Text = filesDone.ToString();
        }

        public static void Run(System.Windows.Controls.ProgressBar p_bar, int filesCount, System.Windows.Controls.Label lbl_totalFiles, int filesDone)
        {
            if (p_bar.Value < filesCount) p_bar.Value++;
            Application.DoEvents();
            lbl_totalFiles.Content = filesDone.ToString();
        }
    }
}
