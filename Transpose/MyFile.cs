using Transpose.Enums;
using Transpose.Interfaces;

namespace Transpose {
    public class MyFile : IFile {

        public Filetype FileType { get; }

        public string Path { get; } = string.Empty;

        public string Delimitter { get; } = string.Empty;

        public MyFile(Filetype type, string path, string delimitter) {
            FileType = type;
            Path = path;
            Delimitter = delimitter;
        }
    }
}
