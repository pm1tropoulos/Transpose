using Transpose.Enums;
using Transpose.Interfaces;

namespace Transpose.Factory {
    public class ProcessFactory {
        public IFileProcess process;
        public IFile _file;

        public ProcessFactory(IFile file) {
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
