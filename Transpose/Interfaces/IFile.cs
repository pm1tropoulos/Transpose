using Transpose.Enums;

namespace Transpose.Interfaces {
    public interface IFile : ICsvFile{
        string Path { get; }
        Filetype FileType { get; }
    }
}
