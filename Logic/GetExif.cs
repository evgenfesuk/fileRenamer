using System;
using System.IO;
using System.Windows.Media.Imaging;

namespace Logic
{
    public static class ExifInfo
    {
        public static string Get(string path)
        {
            if (path == null) throw new ArgumentNullException(nameof(path));
            var foto = File.Open(Path.GetTempFileName(), FileMode.Open, FileAccess.Read);
            try
            {
                foto = File.Open(path, FileMode.Open, FileAccess.Read); // открыли файл для чтения
                return FindInfo(foto);
            }
            catch(Exception)
            {
                return "Corrupted file";
            }
            finally
            {
                foto.Close();
            }
        }

        public static string FindInfo(FileStream foto)
        {
            if (foto == null) throw new ArgumentNullException(nameof(foto));
            var decoder = BitmapDecoder.Create(foto, BitmapCreateOptions.IgnoreColorProfile, BitmapCacheOption.Default);
            var imageMetadata = decoder.Frames[0].Metadata;
            if (imageMetadata == null) return null;
            var tmpImgExif = (BitmapMetadata)imageMetadata.Clone(); //считали и сохранили метаданные
            var fileName = tmpImgExif.DateTaken;
            foto.Close();
            return fileName;

        }
    }
}
