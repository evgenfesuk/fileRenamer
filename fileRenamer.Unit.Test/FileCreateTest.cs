using System;
using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace fileRenamer.Unit.Test
{
    [TestClass]
    public class FileCreateTest
    {
        [TestMethod]
        public void CreatingFileWithPath()
        {
            string _path = "D:\\test.jpg";
            Name.FileCreate(_path);
        }
    }
}
