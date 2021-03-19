using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transpose.Interfaces;

namespace Transpose.Factory {
    public class ProcessFactory {
        public IFileProcess process;
        public MyFile file;

        public ProcessFactory(MyFile _file) {
            file = _file;
        }
        public IFileProcess GetProcess() {
            switch (file.FileType)
            {
                case Enums.fileType.csv:
                process = new TransposeToolCsv(file);
                break;
            }
            return process;
        }

    }
}
