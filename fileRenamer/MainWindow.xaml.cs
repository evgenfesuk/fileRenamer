﻿using System.Windows;
using System.Windows.Controls;
using Dialog;
using ReNamer;


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

        private string _path;

        private void btnReName_Click(object sender, RoutedEventArgs e)
        {
            //reNamer.rename((cmbx.SelectedItem as ComboBoxItem).Content.ToString(), _path);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _path = openDlg.SelectFolder();
            btnReName.IsEnabled = true;
        }
    }
}
