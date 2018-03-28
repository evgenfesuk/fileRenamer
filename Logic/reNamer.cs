using System.IO;
using System.Windows.Forms;

namespace Logic
{
    public static class ReName
    {
        public static void Run(string imgFormat, string _path, ProgressBar bar, Label lblTotalFiles)
        {
            var dirs = Directory.GetFiles(_path, imgFormat);

            int filesCount = 0, filesDone = 0;
            foreach (var path in dirs) filesCount++;

            PBar.Init(bar, filesCount);

            foreach (string path in dirs)
            {
                Name.FileCreate(path);
                filesDone++;
                PBar.Run(bar, filesCount, lblTotalFiles, filesDone);
            }
        }

        public static void Run(string imgFormat, string _path, System.Windows.Controls.ProgressBar bar, System.Windows.Controls.Label lblTotalFiles)
        {
            var dirs = Directory.GetFiles(_path, imgFormat);

            int filesCount = 0, filesDone = 0;
            foreach (var path in dirs) filesCount++;

            PBar.Init(bar, filesCount);

            foreach (var path in dirs)
            {
                Name.FileCreate(path);
                filesDone++;
                PBar.Run(bar, filesCount, lblTotalFiles, filesDone);
            }
        }
    }
}
