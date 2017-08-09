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
            /*string path = txtPath.Text;
            string dir = System.IO.Path.GetDirectoryName(path);
            dir = Directory.GetCurrentDirectory();*/

            string[] dirs = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.jpg");

            foreach (string path in dirs)
            {
                if (!File.Exists(NameCreate(path)))  File.Copy(path, NameCreate(path));
                else
                {
                    File.Copy(path, NameChange(path), true);
                }
                File.Delete(path);
            }

        }

        private string NameChange(string path)
        {
            string fileName = GetExif(path) + "(2)" + System.IO.Path.GetExtension(path);

            fileName = MakeGoodName(fileName);

            string fullFileName = System.IO.Path.Combine(Directory.GetCurrentDirectory(), fileName);


            return fullFileName;
        }

        private string NameCreate(string path)
        {
            string fileName = GetExif(path) + System.IO.Path.GetExtension(path);

            fileName = MakeGoodName(fileName);

            string fullFileName = System.IO.Path.Combine(Directory.GetCurrentDirectory(), fileName);


            return fullFileName;
        }

        private string GetExif(string path)
        {
            FileStream Foto = File.Open(path, FileMode.Open, FileAccess.Read); // открыли файл для чтения
            BitmapDecoder decoder = JpegBitmapDecoder.Create(Foto, BitmapCreateOptions.IgnoreColorProfile, BitmapCacheOption.Default); //"распаковали" снимок и создали объект decoder
            BitmapMetadata TmpImgEXIF = (BitmapMetadata)decoder.Frames[0].Metadata.Clone(); //считали и сохранили метаданные
            string fileName = TmpImgEXIF.DateTaken;
            Foto.Close();
            return fileName;
        }

        private void ClosePhoto(string path)
        {
            FileStream Foto = File.Open(path, FileMode.Open, FileAccess.Read);
            Foto.Close();
        }

        private string MakeGoodName(string fileName)
        {
            fileName = fileName.Replace(" ", "_");
            fileName = fileName.Replace(":", "-");
            return fileName;
        }
    }
}
