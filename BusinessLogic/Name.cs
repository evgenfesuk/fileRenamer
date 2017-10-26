using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BusinessLogic
{
    public static class Name
    {
        public static string Create(string path)
        {
            string fileName = GetExif.getExif(path) + System.IO.Path.GetExtension(path);

            fileName = makeGoodName(fileName);

            string fullFileName = System.IO.Path.Combine(Directory.GetCurrentDirectory(), fileName);


            return fullFileName;
        }

        public static string Change(string path)
        {
            string fileName = GetExif.getExif(path) + "(2)" + System.IO.Path.GetExtension(path);

            fileName = makeGoodName(fileName);

            string fullFileName = System.IO.Path.Combine(Directory.GetCurrentDirectory(), fileName);


            return fullFileName;
        }

        public static string makeGoodName(string fileName)
        {
            fileName = fileName.Replace(" ", "_");
            fileName = fileName.Replace(":", "-");
            return fileName;
        }
    }
}
