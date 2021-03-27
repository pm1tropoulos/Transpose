using Transpose.Enums;
using Transpose.Interfaces;

namespace Transpose.Factory {
    public class ProcessFactory {
        public IFileProcess process;
        public MyFile _file;

        public ProcessFactory(MyFile file) {
            _file = file;
        }
        public IFileProcess GetProcess() {
            switch (_file.FileType)
            {
                case Filetype.CSV:
                process = new TransposeToolCsv(_file);
                break;
            }
            return process;
        }

    }
}
