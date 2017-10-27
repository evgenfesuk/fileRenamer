using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace BusinessLogic
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
