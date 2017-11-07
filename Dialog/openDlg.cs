using System.Windows.Forms;

namespace Dialog
{
    public static class openDlg
    {
        public static string SelectFolder(string fldr)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (fldr != null) dlg.SelectedPath = fldr;
            dlg.ShowDialog();
            return dlg.SelectedPath;

        }
    }
}
