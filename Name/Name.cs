using System.IO;

namespace Name
{
    public static class Name
    {
        private static string Create(string path)
        {
            return Path.Combine(Path.GetDirectoryName(path), MakeGoodName(Exif.GetExif.getExif(path) + Path.GetExtension(path)));
        }

        private static string Create(string path, int counter)
        {
            return Path.Combine(Path.GetDirectoryName(path), MakeGoodName(Exif.GetExif.getExif(path) + " (" + counter.ToString() + ")" + Path.GetExtension(path)));
        }

        private static string MakeGoodName(string fileName)
        {
            if (fileName!=null) fileName = fileName.Substring(6, 4) + "." + fileName.Substring(3, 3) + fileName.Substring(0, 2) + fileName.Substring(10);
            fileName = fileName.Replace(" ", "_");
            fileName = fileName.Replace(":", "-");
            return fileName;
        }

        public static void FileCreate(string path)
        {
            int counter = 0;
            string name = Create(path);

            while (File.Exists(name)) name = Create(path, ++counter);
            FileInfo f = new FileInfo(path);
            f.MoveTo(name);
        }
    }
}
