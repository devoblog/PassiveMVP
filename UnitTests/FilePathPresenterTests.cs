using System;
using MVP.Models;
using MVP.Presenters;
using MVP.Views;
using NSubstitute;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class FilePathPresenterTests
    {
        private IFilePathView _view;
        private IFilePathModel _model;

        [SetUp]
        public void SetUp()
        {
            _view = Substitute.For<IFilePathView>();
            _model = Substitute.For<IFilePathModel>();
        }

        private void CreatePresenter()
        {
            new FilePathPresenter(_view, _model);
        }

        [Test]
        public void FileNamePassedToModelTest()
        {
            string fileName = "MyFile.txt";
            _view.FileName.Returns(fileName);
            CreatePresenter();
            _view.FileNameChanged += Raise.EventWith(_view, EventArgs.Empty);
            _model.Received(1).FileName = fileName;
        }
    }
}