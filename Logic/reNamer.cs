using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Documents;
using System.Windows.Forms;

namespace Logic
{
    public static class ReName
    {
        public static void Run(string imgFormat, string _path, ProgressBar bar, Label lblTotalFiles)
        {
            IEnumerable<string> dirs = Directory.GetFiles(_path, imgFormat);
            int filesCount = dirs.ToList().Count, filesDone = 0;

            PBar.Init(bar, filesCount);

            foreach (var path in dirs)
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
