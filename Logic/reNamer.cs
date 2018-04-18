using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Logic
{
    public static class ReName
    {
        //public static void Run(string imgFormat, string _path, ProgressBar bar, Label lblTotalFiles)
        //{
        //    IEnumerable<string> dirs = Directory.GetFiles(_path, imgFormat);
        //    int filesCount = dirs.ToList().Count, filesDone = 0;

        //    PBar.Init(bar, filesCount);

        //    foreach (var path in dirs)
        //    {
        //        Name.FileCreate(path);
        //        filesDone++;
        //        PBar.Run(bar, filesCount, lblTotalFiles, filesDone);
        //    }
        //}

        public static void Run(string imgFormat, in string _path, in System.Windows.Controls.ProgressBar bar, in System.Windows.Controls.Label lblTotalFiles)
        {
            try
            {
                IEnumerable<string> dirs = Directory.GetFiles(_path, imgFormat);
                int filesCount = dirs.ToList().Count, filesDone = 0;

                PBar.Init(bar, in filesCount);

                foreach (var path in dirs)
                {
                    Name.FileCreate(in path);
                    filesDone++;
                    PBar.Run(bar, filesCount, lblTotalFiles, filesDone);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
