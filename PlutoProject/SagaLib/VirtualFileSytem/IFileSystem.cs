using System.IO;

namespace SagaLib.VirtualFileSystem
{
    public interface IFileSystem
    {
        bool Init(string path);

        Stream OpenFile(string path);

        string[] SearchFile(string path, string pattern);

        string[] SearchFile(string path, string pattern, System.IO.SearchOption option);

        void Close();
    }
}
