using System.Windows;
using System.Windows.Controls;
using Logic;
using static Logic.OpenDlg;


namespace fileRenamer
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow() => InitializeComponent();

        private string _path;

        private void BtnReName_Click(object sender, RoutedEventArgs e)
        {
            ReName.Run((cmbx.SelectedItem as ComboBoxItem)?.Content.ToString(), _path, progressBar1, lbl_total_files);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _path = SelectFolder(_path);
            btnReName.IsEnabled = true;
            SortingBtn.IsEnabled = true;
            DeleteDublicatesBtn.IsEnabled = true;
        }

        private void SortingBtn_Click(object sender, RoutedEventArgs e)
        {
            Folder.Create((cmbx.SelectedItem as ComboBoxItem)?.Content.ToString(), _path, progressBar1, lbl_total_files);
        }

        private void DeleteDublicatesBtn_Click(object sender, RoutedEventArgs e)
        {
            DublicateChecker.Run((cmbx.SelectedItem as ComboBoxItem)?.Content.ToString(), _path, progressBar1, lbl_total_files);
        }
    }
}
