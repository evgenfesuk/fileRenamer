using System.IO;
using System.Windows.Forms;
using prgrsBar;

namespace ReNamer
{
    public static class reNamer
    {
        public static void rename(string imgFormat, string _path, ProgressBar bar, Label lbl_totalFiles)
        {
            string[] dirs = Directory.GetFiles(_path, imgFormat);

            int filesCount = 0, filesDone = 0;
            foreach (string path in dirs) filesCount++;

            p_bar.Init(bar, filesCount);

            foreach (string path in dirs)
            {
                string newName = Name.Name.Create(path);
                if (!File.Exists(newName)) File.Copy(path, newName);
                else
                {
                    File.Copy(path, Name.Name.Change(path), true);
                }
                File.Delete(path);
                filesDone++;
                p_bar.Run(bar, filesCount, lbl_totalFiles, filesDone);
            }
        }
    }
}
