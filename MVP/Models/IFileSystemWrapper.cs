namespace MVP.Models
{
    public interface IFileSystemWrapper
    {
        bool FileExists(string fileName);
        string ReadTextFile(string fileName);
        void SaveFile(string fileName, string text);
    }
}