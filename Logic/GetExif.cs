using System.IO;
using System.Windows.Media.Imaging;

namespace Logic
{
    public static class ExifInfo
    {
        public static string Get(string path)
        {
            FileStream Foto = File.Open(Path.GetTempFileName(), FileMode.Open, FileAccess.Read);
            try
            {
                Foto = File.Open(path, FileMode.Open, FileAccess.Read); // открыли файл для чтения
                return FindInfo(Foto);
            }
            catch(System.Exception)
            {
                return "Corrupted file";
            }
            finally
            {
                Foto.Close();
            }
        }

        static string FindInfo(FileStream Foto)
        {
            BitmapDecoder decoder = JpegBitmapDecoder.Create(Foto, BitmapCreateOptions.IgnoreColorProfile, BitmapCacheOption.Default); //"распаковали" снимок и создали объект decoder
            BitmapMetadata TmpImgEXIF = (BitmapMetadata)decoder.Frames[0].Metadata.Clone(); //считали и сохранили метаданные
            string fileName = TmpImgEXIF.DateTaken;
            Foto.Close();
            return fileName;
        }
    }
}
