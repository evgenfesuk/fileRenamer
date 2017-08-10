using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Globalization;

namespace fileRenamer
{

    public interface IMnainForm
    {
        event EventHandler onBtnClick;
    }
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IMnainForm
    {
        public MainWindow()
        {
            InitializeComponent();
            btnReName.Click += BtnReName_Click;
        }

        private void BtnReName_Click(object sender, RoutedEventArgs e)
        {
            if (onBtnClick != null) onBtnClick(this, EventArgs.Empty);
        }

        public event EventHandler onBtnClick;
    }
}
