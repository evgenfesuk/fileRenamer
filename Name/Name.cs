using System.IO;


namespace Name
{
    public static class Name
    {
        public static string Create(string path)
        {
            string fileName = Exif.GetExif.getExif(path) + Path.GetExtension(path);

            fileName = makeGoodName(fileName);

            string fullFileName = Path.Combine(Path.GetDirectoryName(path), fileName);


            return fullFileName;
        }

        public static string Change(string path)
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
    }
}
