using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dialog;
using ReNamer;

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

        private void button1_Click(object sender, EventArgs e)
        {
            _path = openDlg.SelectFolder();
            btnReName.Enabled = true;
        }

        private void btnReName_Click(object sender, EventArgs e)
        {
            reNamer.rename(cmbx.SelectedItem.ToString(), _path);
        }
    }
}
