using System.IO;

namespace Logic
{
    public static class Folder
    {
        public static void Create(string imgFormat, string _path, System.Windows.Controls.ProgressBar bar, System.Windows.Controls.Label lbl_totalFiles)
        {
            string[] dirs = Directory.GetFiles(_path, imgFormat);
            string dn;

            int filesCount = 0, filesDone = 0;
            foreach (string path in dirs) if (char.IsDigit(Path.GetFileNameWithoutExtension(path).Substring(0, 1), 0)) filesCount++;

            p_bar.Init(bar, filesCount);

            foreach (string path in dirs)
            {
                if(char.IsDigit(Path.GetFileNameWithoutExtension(path).Substring(0, 1), 0))
                {
                    dn = Path.Combine(Path.GetDirectoryName(path) + "\\" + Path.GetFileNameWithoutExtension(path).Substring(0, 4) + "\\");
                    if (!Directory.Exists(dn)) Directory.CreateDirectory(dn);
                    FileInfo f = new FileInfo(path);
                    f.MoveTo(dn + Path.GetFileName(path));
                    filesDone++;
                    p_bar.Run(bar, filesCount, lbl_totalFiles, filesDone);
                }
            }
        }

        public static void Create(string imgFormat, string _path, System.Windows.Controls.ProgressBar bar, System.Windows.Controls.Label lbl_totalFiles, bool checkBoxState)
        {
            string[] dirs = Directory.GetFiles(_path, imgFormat);
            string dn, _month;

            int filesCount = 0, filesDone = 0;
            foreach (string path in dirs) if (char.IsDigit(Path.GetFileNameWithoutExtension(path).Substring(0, 1), 0)) filesCount++;

            p_bar.Init(bar, filesCount);

            foreach (string path in dirs)
            {
                if (char.IsDigit(Path.GetFileNameWithoutExtension(path).Substring(0, 1), 0))
                {
                    _month = Path.GetFileNameWithoutExtension(path).Substring(5, 2);
                    switch(_month)
                    {
                        case "01": dn = Path.Combine(Path.GetDirectoryName(path) + "\\" + Path.GetFileNameWithoutExtension(path).Substring(0, 4) + "\\" + Path.GetFileNameWithoutExtension(path).Substring(5, 2) + "\\");
                    }
                    dn = Path.Combine(Path.GetDirectoryName(path) + "\\" + Path.GetFileNameWithoutExtension(path).Substring(0, 4) + "\\" + Path.GetFileNameWithoutExtension(path).Substring(5, 2) + "\\");
                    if (!Directory.Exists(dn)) Directory.CreateDirectory(dn);
                    FileInfo f = new FileInfo(path);
                    f.MoveTo(dn + Path.GetFileName(path));
                    filesDone++;
                    p_bar.Run(bar, filesCount, lbl_totalFiles, filesDone);
                }
            }
        }
    }
}
