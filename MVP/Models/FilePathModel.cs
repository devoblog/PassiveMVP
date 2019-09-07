using System;

namespace MVP.Models
{
    public class FilePathModel : IFilePathModel
    {
        private string _fileName;
        public event EventHandler FileNameChanged;

        public string FileName
        {
            get => _fileName;
            set
            {
                _fileName = value;
                FileNameChanged?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}