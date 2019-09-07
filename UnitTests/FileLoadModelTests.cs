using System;
using MVP.Models;
using NSubstitute;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class FileLoadModelTests
    {
        private ITextEditorModel _textEditorModel;
        private IFileSystemWrapper _fileSystemWrapper;
        private IFilePathModel _filePathModel;

        [SetUp]
        public void SetUp()
        {
            _textEditorModel = Substitute.For<ITextEditorModel>();
            _fileSystemWrapper = Substitute.For<IFileSystemWrapper>();
            _filePathModel = Substitute.For<IFilePathModel>();
        }

        [TestCase(true)]
        [TestCase(false)]
        public void ModelIsValidIfFileExists(bool fileExists)
        {
            _fileSystemWrapper.FileExists(Arg.Any<string>()).Returns(fileExists);
            IFileLoadModel model = new FileLoadModel(_textEditorModel, _filePathModel, _fileSystemWrapper);
            _filePathModel.FileNameChanged += Raise.EventWith(_filePathModel, EventArgs.Empty);
            Assert.AreEqual(fileExists, model.IsValid);
        }
    }
}