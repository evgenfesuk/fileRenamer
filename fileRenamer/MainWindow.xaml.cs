using System.Windows;
using BusinessLogic;

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
            reNamer.rename();
        }
    }
}
