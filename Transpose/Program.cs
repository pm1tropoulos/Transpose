using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transpose.Factory;
using Transpose.Interfaces;

namespace Transpose
{
    class Program {

        static void Main(string[] args) {


            Console.WriteLine("Please insert the csv File path...");
            string path = Console.ReadLine().ToString();
            string ext = Path.GetExtension(path).Remove(0, 1);
            string[] enums = Enum.GetNames(typeof(Enums.fileType));
            if(!enums.Contains(ext))
                Console.WriteLine("You should choose a format according to Enums!");
            Enums.fileType fileType = (Enums.fileType)Enum.Parse(typeof(Enums.fileType), ext, true);
            Console.WriteLine($"I will read the .csv from the path: {path}\n");
            MyFile myFile = new MyFile(fileType, path, ";");

            ProcessFactory factory = new ProcessFactory(myFile);
            IFileProcess csvProcess = factory.GetProcess();
            csvProcess.ProcessTranspose(myFile);
           
        }


    }
}
