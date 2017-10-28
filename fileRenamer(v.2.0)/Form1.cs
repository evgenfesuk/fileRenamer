using System;
using System.Windows.Forms;
using Dialog;
using ReNamer;

namespace fileRenamer_v._2._0_
{
    public partial class Form1 : Form
    {
        ProgressBar bar;
        public Form1()
        {
            InitializeComponent();
            bar = progressBar1;
            cmbx.SelectedItem = "*.jpg";
        }

        private string _path;

        private void button1_Click(object sender, EventArgs e)
        {
            _path = openDlg.SelectFolder();
            btnReName.Enabled = true;
        }

        private void btnReName_Click(object sender, EventArgs e)
        {
            reNamer.rename(cmbx.SelectedItem.ToString(), _path, bar);
        }
    }
}
