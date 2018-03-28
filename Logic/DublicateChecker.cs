using System;
using System.IO;
using System.Windows.Forms;

namespace Logic
{
    public static class DublicateChecker
    {
        const int BYTES_TO_READ = sizeof(Int64);
        public static void Run(string imgFormat, string _path, System.Windows.Controls.ProgressBar bar, System.Windows.Controls.Label lblTotalFiles)
        {
            var dirs = Directory.GetFiles(_path, imgFormat);
            var filesDone = 0;

            lblTotalFiles.Content = "0";
            for(var i=0; i<dirs.Length-1; i++)
            {
                var f1 = new FileInfo(dirs[i]);
                var f2 = new FileInfo(dirs[i + 1]);
                if (!FilesAreEqual(f1, f2)) continue;
                f1.Delete();
                Application.DoEvents();
                lblTotalFiles.Content = (++filesDone).ToString();
            }
        }

        private static bool FilesAreEqual(FileInfo first, FileInfo second)
        {
            if (first.Length != second.Length)
                return false;

            if (first.FullName == second.FullName)
                return true;

            var iterations = (int)Math.Ceiling((double)first.Length / BYTES_TO_READ);

            using (var fs1 = first.OpenRead())
            using (var fs2 = second.OpenRead())
            {
                var one = new byte[BYTES_TO_READ];
                var two = new byte[BYTES_TO_READ];

                for (var i = 0; i < iterations; i++)
                {
                    fs1.Read(one, 0, BYTES_TO_READ);
                    fs2.Read(two, 0, BYTES_TO_READ);

                    if (BitConverter.ToInt64(one, 0) != BitConverter.ToInt64(two, 0))
                        return false;
                }
            }

            return true;
        }
    }
}
