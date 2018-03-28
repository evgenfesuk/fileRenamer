using System.Windows.Forms;

namespace Logic
{
    public static class OpenDlg
    {
        public static string SelectFolder(string fldr)
        {
            var dlg = new FolderBrowserDialog();
            if (fldr != null) dlg.SelectedPath = fldr;
            dlg.ShowDialog();
            return dlg.SelectedPath;

        }
    }
}
