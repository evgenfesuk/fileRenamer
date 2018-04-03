using System;
using System.IO;

namespace Logic
{
    public static class Name
    {
        private static string Create(in string path)
        {
            var name = ExifInfo.Get(path);
            if (name!=null)
            {
                return name== "Corrupted file" ? Path.Combine(Path.GetDirectoryName(path) ?? throw new InvalidOperationException(), name + Path.GetExtension(path)) : Path.Combine(Path.GetDirectoryName(path) ?? throw new InvalidOperationException(), MakeGoodName(name + Path.GetExtension(path)));
            }

            return Path.Combine(Path.GetDirectoryName(path) ?? throw new InvalidOperationException(), ("No date" + Path.GetExtension(path)));
        }

        private static string Create(in string path, int counter)
        {
            var name = ExifInfo.Get(path);
            if (name != null)
            {
                return name == "Corrupted file" ? Path.Combine(Path.GetDirectoryName(path) ?? throw new InvalidOperationException(), name + " (" + counter + ")" + Path.GetExtension(path)) : Path.Combine(Path.GetDirectoryName(path) ?? throw new InvalidOperationException(), MakeGoodName(name + " (" + counter + ")" + Path.GetExtension(path)));
            }

            return Path.Combine(Path.GetDirectoryName(path) ?? throw new InvalidOperationException(), ("No date (" + counter + ")" + Path.GetExtension(path)));
        }

        private static string MakeGoodName(string fileName)
        {
            fileName = fileName.Substring(6, 4) + "." + fileName.Substring(3, 3) + fileName.Substring(0, 2) + fileName.Substring(10);
            //fileName = fileName.Replace(" ", "_");
            fileName = fileName.Replace(":", "-");
            return fileName;
        }

        public static void FileCreate(in string path)
        {
            var counter = 1;
            var name = Create(in path);

            while (File.Exists(name)) name = Create(in path, ++counter);
            var f = new FileInfo(path);
            f.MoveTo(name);
        }
    }
}
