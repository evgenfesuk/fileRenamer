using System.Windows;
using BusinessLogic;
using System.Windows.Controls;

namespace fileRenamer
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnReName_Click(object sender, RoutedEventArgs e)
        {
            reNamer.rename((cmbx.SelectedItem as ComboBoxItem).Content.ToString());
        }

    }
}
