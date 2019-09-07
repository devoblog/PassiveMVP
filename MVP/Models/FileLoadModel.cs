using System.Runtime.CompilerServices;
using System;
[assembly: InternalsVisibleTo("UnitTests")]

namespace MVP.Models
{
    public class FileLoadModel : IFileLoadModel
    {
        private readonly ITextEditorModel _textEditorModel;
        private readonly IFilePathModel _filePathModel;
        private readonly IFileSystemWrapper _fileSystemWrapper;
        public event EventHandler Validated;

        private bool _isValid;

        public FileLoadModel(ITextEditorModel textEditorModel, IFilePathModel filePathModel)
            : this(textEditorModel, filePathModel, new FileSystemWrapper())
        {
        }

        internal FileLoadModel(ITextEditorModel textEditorModel, IFilePathModel filePathModel,
            IFileSystemWrapper fileSystemWrapper)
        {
            _textEditorModel = textEditorModel;
            _filePathModel = filePathModel;
            _fileSystemWrapper = fileSystemWrapper;

            _filePathModel.FileNameChanged += (sender, args) => Validate();
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
        
        public void LoadFile()
        {
            _textEditorModel.Text = _fileSystemWrapper.ReadTextFile(_filePathModel.FileName);
        }

        private void Validate()
        {
            IsValid = _fileSystemWrapper.FileExists(_filePathModel.FileName);
        }
    }
}