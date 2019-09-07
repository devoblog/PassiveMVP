namespace MVP.Models
{
    public class FileSaveModel : IFileSaveModel
    {
        private readonly ITextEditorModel _textEditorModel;
        private readonly IFilePathModel _filePathModel;
        private readonly IFileSystemWrapper _fileSystemWrapper;

        public FileSaveModel(ITextEditorModel textEditorModel, IFilePathModel filePathModel)
            : this(textEditorModel, filePathModel, new FileSystemWrapper())
        {

        }

        internal FileSaveModel(ITextEditorModel textEditorModel, IFilePathModel filePathModel,
            IFileSystemWrapper fileSystemWrapper)
        {
            _textEditorModel = textEditorModel;
            _filePathModel = filePathModel;
            _fileSystemWrapper = fileSystemWrapper;
        }

        public void SaveFile()
        {
            _fileSystemWrapper.SaveFile(_filePathModel.FileName, _textEditorModel.Text);
        }
    }
}