using Transpose.Enums;
using Transpose.Interfaces;

namespace Transpose.Factory {
    public class ProcessFactory {
        
        public static IFileProcess GetProcess(IFile file) {
            IFileProcess process = null;
            switch (file.FileType)
            {
                case Filetype.CSV:
                process = new TransposeToolCsv(file);
                break;
            }
            return process;
        }

    }
}
