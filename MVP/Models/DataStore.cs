namespace MVP.Models
{
    public class DataStore : NotifyPropertyChanged, IDataStore
    {
        private readonly IFileSystemWrapper _fileSystemWrapper;
        private string _fileName;
        private string _text;
        private bool _fileNameIsValid;

        public DataStore()
            : this(new FileSystemWrapper())
        {
        }

        public DataStore(IFileSystemWrapper fileSystemWrapper)
        {
            _fileSystemWrapper = fileSystemWrapper;
        }

        public string FileName
        {
            get => _fileName;
            set
            {
                _fileName = value;
                CheckIfFileNameIsValid();
            }
        }

        private void CheckIfFileNameIsValid()
        {
            FileNameIsValid = _fileSystemWrapper.FileExists(FileName);
        }

        public bool FileNameIsValid
        {
            get => _fileNameIsValid;
            set
            {
                _fileNameIsValid = value;
                OnPropertyChanged();
            }
        }

        public string Text
        {
            get => _text;
            set
            {
                _text = value;
                OnPropertyChanged();
            }
        }

        public void Load()
        {
            Text = _fileSystemWrapper.ReadTextFile(FileName);
        }

        public void Save()
        {
            _fileSystemWrapper.SaveFile(FileName, Text);
        }
    }
}