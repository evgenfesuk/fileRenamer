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
                //Name.Name.Create(path);
                Name.Name.fileCreate(path);
                filesDone++;
                p_bar.Run(bar, filesCount, lbl_totalFiles, filesDone);
            }
        }
    }
}
