using System.Runtime.CompilerServices;
using System;
[assembly: InternalsVisibleTo("UnitTests")]

namespace MVP.Models
{
    public class FileLoadModel : IFileLoadModel
    {
        private readonly IFileSystemWrapper _fileSystemWrapper;
        public event EventHandler Validated;

        private bool _isValid;
        private string _fileName;

        public FileLoadModel()
            : this(new FileSystemWrapper())
        {
        }

        internal FileLoadModel(IFileSystemWrapper fileSystemWrapper)
        {
            _fileSystemWrapper = fileSystemWrapper;
        }

        public bool IsValid
        {
            get => _isValid;
            set
            {
                _isValid = value;
                Validated?.Invoke(this, EventArgs.Empty);
            }
        }

        public string FileName
        {
            get => _fileName;
            set
            {
                _fileName = value;
                Validate();
            }
        }

        public void LoadFile()
        {
            
        }

        private void Validate()
        {
            IsValid = _fileSystemWrapper.FileExists(_fileName);
        }
    }
}