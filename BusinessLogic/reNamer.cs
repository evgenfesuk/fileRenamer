using System.IO;
using System.Windows.Forms;
using System.Windows.Media.Imaging;

namespace BusinessLogic
{
    public static class reNamer
    {
        public static void rename(string imgFormat, string _path)
        {
            string[] dirs = Directory.GetFiles(_path, imgFormat);

            foreach (string path in dirs)
            {
                string newName = Name.Create(path);
                if (!File.Exists(newName)) File.Copy(path, newName);
                else
                {
                    File.Copy(path, Name.Change(path), true);
                }
                File.Delete(path);
            }
            
            MessageBox.Show("Done!");
        }
    }
}
