using MVP.Models;
using NSubstitute;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class FilePathModelTests
    {
        [Test]
        public void ValidatedEventRaisedWhenFileNameChanges()
        {
            int counter = 0;
            IFilePathModel model = new FilePathModel();
            model.FileNameChanged += (sender, args) => counter++;
            model.FileName = "MyFile.txt";
            Assert.AreEqual(1, counter);
        }
    }

    [TestFixture]
    public class FileSaveModelTests
    {
        [Test]
        public void SavePassedSaveRequestPassedOn()
        {
            ITextEditorModel textEditorModel = Substitute.For<ITextEditorModel>();
            IFilePathModel filePathModel = Substitute.For<IFilePathModel>();
            IFileSystemWrapper fileSystemWrapper = Substitute.For<IFileSystemWrapper>();

            filePathModel.FileName.Returns("MyFileName.txt");
            textEditorModel.Text.Returns("MyText");

            IFileSaveModel fileSaveModel = new FileSaveModel(textEditorModel, filePathModel, fileSystemWrapper);
            fileSaveModel.SaveFile();

            fileSystemWrapper.Received(1).SaveFile("MyFileName.txt", "MyText");
        }
    }
}