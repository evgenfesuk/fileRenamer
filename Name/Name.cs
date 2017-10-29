using System.IO;

namespace Name
{
    public static class Name
    {
        public static void Create(string path)
        {
            string fileName = Exif.GetExif.getExif(path) + Path.GetExtension(path);
            int counter = 0;
            fileName = makeGoodName(fileName);

            string fullFileName = Path.Combine(Path.GetDirectoryName(path), fileName);

            while (File.Exists(fullFileName))
            {
                do
                    if (!File.Exists(fullFileName))
                    {
                        fileCreate(fullFileName, path);
                        fileDelete(path);
                    }
                    else
                    {
                        counter++;
                        fullFileName = Change(path, counter);
                    }
            }

        }

        public static string Change(string path, int counter)
        {
            string fileName = Exif.GetExif.getExif(path) + "(2)" + Path.GetExtension(path);

            fileName = makeGoodName(fileName);

            string fullFileName = Path.Combine(Path.GetDirectoryName(path), fileName);


            return fullFileName;
        }

        public static string makeGoodName(string fileName)
        {
            fileName = fileName.Replace(" ", "_");
            fileName = fileName.Replace(":", "-");
            return fileName;
        }

        private static void fileCreate(string fileName, string path)
        {
            File.Copy(path, fileName);
        }

        private static void fileDelete(string path)
        {
            File.Delete(path);
        }
    }
}
