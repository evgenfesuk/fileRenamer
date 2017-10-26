using System.IO;
using System.Windows.Media.Imaging;

namespace BusinessLogic
{
    public interface IReNamer
    {
        string GetExif(string path);
        string NameChange(string path);
        string NameCreate(string path);
        string MakeGoodName(string fileName);
        void ReName();
    }
    public class reNamer : IReNamer
    {
        public string GetExif(string path)
        {
            FileStream Foto = File.Open(path, FileMode.Open, FileAccess.Read); // открыли файл для чтения
            BitmapDecoder decoder = JpegBitmapDecoder.Create(Foto, BitmapCreateOptions.IgnoreColorProfile, BitmapCacheOption.Default); //"распаковали" снимок и создали объект decoder
            BitmapMetadata TmpImgEXIF = (BitmapMetadata)decoder.Frames[0].Metadata.Clone(); //считали и сохранили метаданные
            string fileName = TmpImgEXIF.DateTaken;
            Foto.Close();
            return fileName;
        }

        public string NameChange(string path)
        {
            string fileName = GetExif(path) + "(2)" + System.IO.Path.GetExtension(path);

            fileName = MakeGoodName(fileName);

            string fullFileName = System.IO.Path.Combine(Directory.GetCurrentDirectory(), fileName);


            return fullFileName;
        }

        public string NameCreate(string path)
        {
            string fileName = GetExif(path) + System.IO.Path.GetExtension(path);

            fileName = MakeGoodName(fileName);

            string fullFileName = System.IO.Path.Combine(Directory.GetCurrentDirectory(), fileName);


            return fullFileName;
        }

        public string MakeGoodName(string fileName)
        {
            fileName = fileName.Replace(" ", "_");
            fileName = fileName.Replace(":", "-");
            return fileName;
        }

        public void ReName()
        {
            string[] dirs = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.jpg");

            foreach (string path in dirs)
            {
                string newName = NameCreate(path);
                if (!File.Exists(newName)) File.Copy(path, newName);
                else
                {
                    File.Copy(path, NameChange(path), true);
                }
                File.Delete(path);
            }
        }
    }
}
