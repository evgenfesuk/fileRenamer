using System.Windows.Forms;

namespace Dialog
{
    public static class openDlg
    {
        public static string SelectFolder()
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            dlg.ShowDialog();
            return dlg.SelectedPath;
        }
    }
}
