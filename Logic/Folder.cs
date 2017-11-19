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
                        case "01": dn = Path.Combine(Path.GetDirectoryName(path) + "\\" + Path.GetFileNameWithoutExtension(path).Substring(0, 4) + "\\01 Январь\\"); break;
                        case "02": dn = Path.Combine(Path.GetDirectoryName(path) + "\\" + Path.GetFileNameWithoutExtension(path).Substring(0, 4) + "\\02 Февраль\\"); break;
                        case "03": dn = Path.Combine(Path.GetDirectoryName(path) + "\\" + Path.GetFileNameWithoutExtension(path).Substring(0, 4) + "\\03 Март\\"); break;
                        case "04": dn = Path.Combine(Path.GetDirectoryName(path) + "\\" + Path.GetFileNameWithoutExtension(path).Substring(0, 4) + "\\04 Апрель\\"); break;
                        case "05": dn = Path.Combine(Path.GetDirectoryName(path) + "\\" + Path.GetFileNameWithoutExtension(path).Substring(0, 4) + "\\05 Май\\"); break;
                        case "06": dn = Path.Combine(Path.GetDirectoryName(path) + "\\" + Path.GetFileNameWithoutExtension(path).Substring(0, 4) + "\\06 Июнь\\"); break;
                        case "07": dn = Path.Combine(Path.GetDirectoryName(path) + "\\" + Path.GetFileNameWithoutExtension(path).Substring(0, 4) + "\\07 Июль\\"); break;
                        case "08": dn = Path.Combine(Path.GetDirectoryName(path) + "\\" + Path.GetFileNameWithoutExtension(path).Substring(0, 4) + "\\08 Август\\"); break;
                        case "09": dn = Path.Combine(Path.GetDirectoryName(path) + "\\" + Path.GetFileNameWithoutExtension(path).Substring(0, 4) + "\\09 Сентябрь\\"); break;
                        case "10": dn = Path.Combine(Path.GetDirectoryName(path) + "\\" + Path.GetFileNameWithoutExtension(path).Substring(0, 4) + "\\10 Октябрь\\"); break;
                        case "11": dn = Path.Combine(Path.GetDirectoryName(path) + "\\" + Path.GetFileNameWithoutExtension(path).Substring(0, 4) + "\\11 Ноябрь\\"); break;
                        case "12": dn = Path.Combine(Path.GetDirectoryName(path) + "\\" + Path.GetFileNameWithoutExtension(path).Substring(0, 4) + "\\12 Декабрь\\"); break;
                        default: dn = dn = Path.Combine(Path.GetDirectoryName(path) + "\\" + Path.GetFileNameWithoutExtension(path).Substring(0, 4) + "\\"); break;
                    }
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
