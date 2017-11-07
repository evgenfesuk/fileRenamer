using System;
using System.IO;
using System.Windows.Forms;

namespace Logic
{
    public static class DublicateChecker
    {
        const int BYTES_TO_READ = sizeof(Int64);
        public static void Run(string imgFormat, string _path, System.Windows.Controls.ProgressBar bar, System.Windows.Controls.Label lbl_totalFiles)
        {
            string[] dirs = Directory.GetFiles(_path, imgFormat);
            FileInfo f1, f2;
            int filesDone = 0;

            lbl_totalFiles.Content = "0";
            for(int i=0; i<dirs.Length-1; i++)
            {
                f1 = new FileInfo(dirs[i]);
                f2 = new FileInfo(dirs[i + 1]);
                if (FilesAreEqual(f1, f2))
                {
                    f1.Delete();
                    Application.DoEvents();
                    lbl_totalFiles.Content = (++filesDone).ToString();
                }
            }
        }

        static bool FilesAreEqual(FileInfo first, FileInfo second)
        {
            if (first.Length != second.Length)
                return false;

            if (first.FullName == second.FullName)
                return true;

            int iterations = (int)Math.Ceiling((double)first.Length / BYTES_TO_READ);

            using (FileStream fs1 = first.OpenRead())
            using (FileStream fs2 = second.OpenRead())
            {
                byte[] one = new byte[BYTES_TO_READ];
                byte[] two = new byte[BYTES_TO_READ];

                for (int i = 0; i < iterations; i++)
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
