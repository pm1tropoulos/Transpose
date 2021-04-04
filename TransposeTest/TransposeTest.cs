using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Transpose;
using Transpose.Factory;
using Transpose.Interfaces;
using Transpose.Enums;

namespace TransposeTest {
    [TestClass]
    public class TransposeTest {
                
        [TestMethod]
        public void Test_TransposeToolCsv_File_Does_Not_Exist() {
            string path = @"Data\Test2.csv";
            string ext = Path.GetExtension(path).Remove(0, 1);
            Filetype fileType = (Filetype)Enum.Parse(typeof(Filetype), ext, true);
            string expected = "The file you provided does not exist";
            
            using (var sw = new StringWriter()) {
                Console.SetOut(sw);
                MyFile myFile = new MyFile(fileType, path, ";");
                IFileProcess fileProcess = ProcessFactory.GetProcess(myFile);
                fileProcess.ProcessTranspose(myFile);

                var result = sw.ToString().Trim();
                Assert.AreEqual(expected, result);
            }
        }

        [TestMethod]
        public void Test_TransposeToolCsv_File_Has_No_Content() {
            string path = @"Data\Test_4.csv";
            string ext = Path.GetExtension(path).Remove(0, 1);
            Filetype fileType = (Filetype)Enum.Parse(typeof(Filetype), ext, true);
            string expected = "The file you provided has no content";

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                MyFile myFile = new MyFile(fileType, path, ";");
                IFileProcess fileProcess = ProcessFactory.GetProcess(myFile);
                fileProcess.ProcessTranspose(myFile);

                var result = sw.ToString().Trim();
                Assert.AreEqual(expected, result);
            }
        }
    }
}
