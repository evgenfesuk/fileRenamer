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
            string path = txtPath.Text;
            string dir = System.IO.Path.GetDirectoryName(path);
            //label1.Content = File.GetCreationTime(path);

            FileStream Foto = File.Open(path, FileMode.Open, FileAccess.Read); // открыли файл для чтения
            BitmapDecoder decoder = JpegBitmapDecoder.Create(Foto, BitmapCreateOptions.IgnoreColorProfile, BitmapCacheOption.Default); //"распаковали" снимок и создали объект decoder
            BitmapMetadata TmpImgEXIF = (BitmapMetadata)decoder.Frames[0].Metadata.Clone(); //считали и сохранили метаданные

            //DateTime DateOfShot = Convert.ToDateTime(TmpImgEXIF.DateTaken);

            string fileName = TmpImgEXIF.DateTaken;
            fileName += System.IO.Path.GetExtension(path);
            fileName = fileName.Replace(" ", "_");
            fileName = fileName.Replace(":", "-");

            string fullFileName = System.IO.Path.Combine(dir, fileName);
            
            Foto.Close();
            File.Copy(path, fullFileName);
            File.Delete(path);
        }
    }
}
