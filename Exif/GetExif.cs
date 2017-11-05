﻿using System.IO;
using System.Windows.Media.Imaging;

namespace Exif
{
    public static class GetExif
    {
        public static string getExif(string path)
        {
            FileStream Foto = File.Open(path, FileMode.Open, FileAccess.Read); // открыли файл для чтения
            BitmapDecoder decoder = JpegBitmapDecoder.Create(Foto, BitmapCreateOptions.IgnoreColorProfile, BitmapCacheOption.Default); //"распаковали" снимок и создали объект decoder
            BitmapMetadata TmpImgEXIF = (BitmapMetadata)decoder.Frames[0].Metadata.Clone(); //считали и сохранили метаданные
            string fileName = TmpImgEXIF.DateTaken.Substring(6, 4) + "." + TmpImgEXIF.DateTaken.Substring(3, 3) + TmpImgEXIF.DateTaken.Substring(0, 2) + TmpImgEXIF.DateTaken.Substring(10); ;
            Foto.Close();
            return fileName;
        }
    }
}
