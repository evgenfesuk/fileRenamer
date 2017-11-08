using System.IO;

namespace Logic
{
    public static class Name
    {
        private static string Create(string path)
        {
            string name = ExifInfo.Get(path);
            if (name!=null) return Path.Combine(Path.GetDirectoryName(path), MakeGoodName(name + Path.GetExtension(path)));
            else return Path.Combine(Path.GetDirectoryName(path), ("No_date" + Path.GetExtension(path)));
        }

        private static string Create(string path, int counter)
        {
            string name = ExifInfo.Get(path);
            if (name != null)  return Path.Combine(Path.GetDirectoryName(path), MakeGoodName(name + " (" + counter.ToString() + ")" + Path.GetExtension(path)));
            else return Path.Combine(Path.GetDirectoryName(path), ("No_date" + "_(" + counter.ToString() + ")" + Path.GetExtension(path)));
        }

        private static string MakeGoodName(string fileName)
        {
            fileName = fileName.Substring(6, 4) + "." + fileName.Substring(3, 3) + fileName.Substring(0, 2) + fileName.Substring(10);
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
