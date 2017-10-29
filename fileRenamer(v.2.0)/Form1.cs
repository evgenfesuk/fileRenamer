using System;
using System.Windows.Forms;
using Dialog;

namespace fileRenamer_v._2._0_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            cmbx.SelectedItem = "*.jpg";
        }

        private string _path;

        private void Button1_Click(object sender, EventArgs e)
        {
            _path = openDlg.SelectFolder();
            btnReName.Enabled = true;
        }

        private void BtnReName_Click(object sender, EventArgs e)
        {
            ReNamer.ReNamer.Rename(cmbx.SelectedItem.ToString(), _path, progressBar1, lbl_total_files);
        }
    }
}
