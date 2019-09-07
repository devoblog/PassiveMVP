using System.IO;

namespace MVP.Models
{
    public class FileSystemWrapper : IFileSystemWrapper
    {
        public bool FileExists(string fileName)
        {
            return File.Exists(fileName);
        }

        public string ReadTextFile(string fileName)
        {
            return File.ReadAllText(fileName);
        }

        public void SaveFile(string fileName, string text)
        {
            File.WriteAllText(fileName, text);
        }
    }
}