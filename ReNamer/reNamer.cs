using System.IO;
using System.Windows.Forms;
using prgrsBar;
using NameBL;

namespace ReNamer
{
    public static class ReName
    {
        public static void Run(string imgFormat, string _path, ProgressBar bar, Label lbl_totalFiles)
        {
            string[] dirs = Directory.GetFiles(_path, imgFormat);

            int filesCount = 0, filesDone = 0;
            foreach (string path in dirs) filesCount++;

            p_bar.Init(bar, filesCount);

            foreach (string path in dirs)
            {
                Name.FileCreate(path);
                filesDone++;
                p_bar.Run(bar, filesCount, lbl_totalFiles, filesDone);
            }
        }

        public static void Run(string imgFormat, string _path, System.Windows.Controls.ProgressBar bar, System.Windows.Controls.Label lbl_totalFiles)
        {
            string[] dirs = Directory.GetFiles(_path, imgFormat);

            int filesCount = 0, filesDone = 0;
            foreach (string path in dirs) filesCount++;

            p_bar.Init(bar, filesCount);

            foreach (string path in dirs)
            {
                Name.FileCreate(path);
                filesDone++;
                p_bar.Run(bar, filesCount, lbl_totalFiles, filesDone);
            }
        }
    }
}
