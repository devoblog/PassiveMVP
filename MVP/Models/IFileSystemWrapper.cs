namespace MVP.Models
{
    public interface IFileSystemWrapper
    {
        bool FileExists(string fileName);
    }
}