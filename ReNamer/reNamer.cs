using System.IO;
using System.Windows.Forms;

namespace ReNamer
{
    public static class reNamer
    {
        public static void rename(string imgFormat, string _path, ProgressBar bar)
        {
            string[] dirs = Directory.GetFiles(_path, imgFormat);

            int filesCount = 0;
            foreach (string path in dirs) filesCount++;
            bar.Value = 0;
            bar.Maximum = filesCount;
            foreach (string path in dirs)
            {
                if (bar.Value < filesCount) bar.Value++;
                string newName = Name.Name.Create(path);
                if (!File.Exists(newName)) File.Copy(path, newName);
                else
                {
                    File.Copy(path, Name.Name.Change(path), true);
                }
                File.Delete(path);
            }
        }
    }
}
