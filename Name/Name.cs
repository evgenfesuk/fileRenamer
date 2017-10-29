using System.IO;

namespace Name
{
    public static class Name
    {
        private static string Create(string path)
        {
            return Path.Combine(Path.GetDirectoryName(path), makeGoodName(Exif.GetExif.getExif(path) + Path.GetExtension(path)));
        }

        private static string Create(string path, int counter)
        {
            return Path.Combine(Path.GetDirectoryName(path), makeGoodName(Exif.GetExif.getExif(path) + " (" + counter.ToString() + ")" + Path.GetExtension(path)));
        }

        private static string makeGoodName(string fileName)
        {
            fileName = fileName.Replace(" ", "_");
            fileName = fileName.Replace(":", "-");
            return fileName;
        }

        public static void fileCreate(string path)
        {
            int counter = 0;
            string name = Create(path);

            while (File.Exists(name))
            {
                counter++;
                name = Create(path, counter);
            }
            File.Copy(path, name);
            fileDelete(path);
        }
        
        private static void fileDelete(string path)
        {
            File.Delete(path);
        }
    }
}
