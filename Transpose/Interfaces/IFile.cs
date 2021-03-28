using Transpose.Enums;

namespace Transpose.Interfaces {
    public interface IFile{
        string Path { get; }
        Filetype FileType { get; }
        string Delimitter { get; }
        }
}
