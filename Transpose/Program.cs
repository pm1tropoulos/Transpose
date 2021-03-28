using System;
using System.IO;
using System.Linq;
using Transpose.Factory;
using Transpose.Interfaces;
using Transpose.Enums;

namespace Transpose {
    class Program {

        static void Main(string[] args) {


            Console.WriteLine("Please insert the csv File path...");
            string path = Console.ReadLine().ToString();
            string ext = Path.GetExtension(path).Remove(0, 1);
            string[] enums = Enum.GetNames(typeof(Filetype));
            if(!enums.Contains(ext))
                Console.WriteLine("You should choose a format according to Enums!");
            Filetype fileType = (Filetype)Enum.Parse(typeof(Filetype), ext, true);
            Console.WriteLine($"I will read the .csv from the path: {path}\n");
            IFile myFile = new MyFile(fileType, path, ";");

            ProcessFactory factory = new ProcessFactory(myFile);
            IFileProcess csvProcess = factory.GetProcess();
            csvProcess.ProcessTranspose(myFile);
           
        }


    }
}
