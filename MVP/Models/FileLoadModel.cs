using System.Runtime.CompilerServices;
using System;
[assembly: InternalsVisibleTo("UnitTests")]

namespace MVP.Models
{
    public class FileLoadModel : IFileLoadModel
    {
        private readonly ITextEditorModel _textEditorModel;
        private readonly IFileSystemWrapper _fileSystemWrapper;
        public event EventHandler Validated;

        private bool _isValid;
        private string _fileName;

        public FileLoadModel(ITextEditorModel textEditorModel)
            : this(textEditorModel, new FileSystemWrapper())
        {
        }

        internal FileLoadModel(ITextEditorModel textEditorModel, IFileSystemWrapper fileSystemWrapper)
        {
            _textEditorModel = textEditorModel;
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
            _textEditorModel.Text = _fileSystemWrapper.ReadTextFile(_fileName);
        }

        private void Validate()
        {
            IsValid = _fileSystemWrapper.FileExists(_fileName);
        }
    }
}