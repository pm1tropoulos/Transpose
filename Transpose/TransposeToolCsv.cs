using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using Transpose.Interfaces;

namespace Transpose {
    public class TransposeToolCsv : IFileProcess {

        private MyFile _myFile;

        public TransposeToolCsv(MyFile file) {
            _myFile = file;
        }


        /// <summary>
        /// Concrete ReadFile for csv files
        /// </summary>
        /// <param name="path"></param>
        /// <param name="Type"></param>
        /// <returns></returns>
        public void ProcessTranspose(MyFile file) {


            DataTable myDt = new DataTable
            {
                TableName = "TransportedCSV"
            };

            if (!File.Exists(file.Path))
            {
                Console.WriteLine("The file you provided does not exist");
            }

            else
            {
                var Length = new FileInfo(file.Path).Length;
                if (Length == 0)
                {
                    Console.WriteLine("The file you provided has no content");
                }

                else
                {

                    try
                    {
                        using (var sr = new StreamReader(file.Path))
                        {
                            while (!sr.EndOfStream)
                            {
                                string[] line = sr.ReadLine().Split(file.Delimitter.ToCharArray());
                                DataColumn column = myDt.Columns.Add();
                                foreach (string value in line)
                                {
                                    myDt.Rows.Add();
                                    myDt.Rows[Array.IndexOf(line, value)][column] = value;
                                }
                            }
                        }
                        Console.WriteLine("Transformation fininshed !!!");
                        ExportFile(myDt, file.Path);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("**************************************");
                        Console.WriteLine(ex.Message);
                        Console.WriteLine("**************************************\n");
                    }
                }

            }
        }

        /// <summary>
        /// Exports the dataTable parameter into a specific path
        /// </summary>
        /// <param name="tbl"></param>
        /// <param name="path"></param>
        public void ExportFile(DataTable tbl, string path) {
            var exportPath = path.Insert(path.LastIndexOf(Path.GetExtension(path)), "_transposed");
            Console.WriteLine($"Export started .... \n");
            StringBuilder sb = new StringBuilder();
            try
            {
                foreach (DataRow row in tbl.Rows)
                {
                    if (!row.ItemArray.All(r => r is DBNull))
                    {
                        IEnumerable<string> fields = row.ItemArray.Select(field => field.ToString());
                        sb.AppendLine(string.Join(_myFile.Delimitter, fields));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            File.WriteAllText(exportPath, sb.ToString());
            Console.WriteLine($"File is placed at: {exportPath}");
        }
    }
}
