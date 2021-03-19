using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Transpose;
using Transpose.Factory;
using Transpose.Interfaces;

namespace TransposeTest {
    [TestClass]
    public class TransposeTest {
                
        [TestMethod]
        public void Test_TransposeToolCsv_File_Does_Not_Exist() {
            string path = "C:\\Users\\PANAGIOTIS\\Documents\\TECAN\\Test2.csv";
            string ext = Path.GetExtension(path).Remove(0, 1);
            Transpose.Enums.fileType fileType = (Transpose.Enums.fileType)Enum.Parse(typeof(Transpose.Enums.fileType), ext, true);
            string expected = "The file you provided does not exist";
            
            using (var sw = new StringWriter()) {
                Console.SetOut(sw);
                MyFile myFile = new MyFile(fileType, path, ";");
                ProcessFactory factory = new ProcessFactory(myFile);
                IFileProcess csvProcess = factory.GetProcess();
                csvProcess.ProcessTranspose(myFile);

                var result = sw.ToString().Trim();
                Assert.AreEqual(expected, result);
            }
        }

        [TestMethod]
        public void Test_TransposeToolCsv_File_Has_No_Content() {
            string path = "C:\\Users\\PANAGIOTIS\\Documents\\TECAN\\Test_4.csv";
            string ext = Path.GetExtension(path).Remove(0, 1);
            Transpose.Enums.fileType fileType = (Transpose.Enums.fileType)Enum.Parse(typeof(Transpose.Enums.fileType), ext, true);
            string expected = "The file you provided has no content";

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                MyFile myFile = new MyFile(fileType, path, ";");
                ProcessFactory factory = new ProcessFactory(myFile);
                IFileProcess csvProcess = factory.GetProcess();
                csvProcess.ProcessTranspose(myFile);

                var result = sw.ToString().Trim();
                Assert.AreEqual(expected, result);
            }
        }
    }
}
