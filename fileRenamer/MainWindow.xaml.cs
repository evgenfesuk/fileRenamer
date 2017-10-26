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

            string[] dirs = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.jpg"); // ищем все картинки по расширению

            foreach (string path in dirs) // path автоматически вытягивается при каждом проходе из dir
            {
                string newName = NameCreate(path); // создаём имя для файла в path, делаем это один раз для повышения скорости работы программы
                if (!File.Exists(newName))  File.Copy(path, newName); // если файла с таким именем нету делаем копию оригинального файла с новым именем
                else
                {
                    File.Copy(path, NameChange(path), true); // иначе меняем имя
                }
                
                // File.Equals(path, newName); неплохо бы добавить проверку двух файлов для избежания ошибок при копировании и удалении единственной копии файла
                File.Delete(path); // удаляем оригинальный файл
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
