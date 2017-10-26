﻿using System.IO;
using System.Windows.Media.Imaging;

namespace BusinessLogic
{
    public interface IReNamer
    {
        void ReName();
    }
    public static class reNamer
    {
        public static void rename()
        {
            string[] dirs = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.jpg");

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
        }
    }
}
