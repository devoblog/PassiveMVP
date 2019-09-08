using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using MVP.Models;
using MVP.Presenters;
using MVP.Views;
using NSubstitute;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class MainPresenterTests
    {
        private IMainView _view;
        private IDataStore _dataStore;

        [SetUp]
        public void SetUp()
        {
            _view = Substitute.For<IMainView>();
            _dataStore = Substitute.For<IDataStore>();
        }

        private void CreatePresenter()
        {
            new MainPresenter(_view, _dataStore);
        }

        [Test]
        public void InitialIsValidPassedToModel()
        {
            _dataStore.FileNameIsValid.Returns(false);
            CreatePresenter();
            _view.Received(1).FileNameIsValid = false;
        }

        [Test]
        public void LoadFileRequestPassedToModel()
        {
            CreatePresenter();
            _view.LoadRequested += Raise.EventWith(_view, EventArgs.Empty);
            _dataStore.Received(1).Load();
        }

        [TestCase(true)]
        [TestCase(false)]
        public void IsValidPassedToViewInitiallyTest(bool isValid)
        {
            _dataStore.FileNameIsValid.Returns(isValid);
            CreatePresenter();
            _view.ClearReceivedCalls();
            _dataStore.PropertyChanged += Raise.Event<PropertyChangedEventHandler>(
                    _dataStore, new PropertyChangedEventArgs("FileNameIsValid"));
            _view.Received(1).FileNameIsValid = isValid;
        }

        [TestCase(true)]
        [TestCase(false)]
        public void CanSavePassedToViewInitiallyTest(bool canSave)
        {
            _dataStore.CanSave.Returns(canSave);
            CreatePresenter();
            _view.Received(1).CanSave = canSave;
        }

        [Test]
        public void FileNamePassedToModelTest()
        {
            string fileName = "MyFile.txt";
            _view.FileName.Returns(fileName);
            CreatePresenter();
            _view.FileNameChanged += Raise.EventWith(_view, EventArgs.Empty);
            _dataStore.Received(1).FileName = fileName;
        }

        [Test]
        public void SaveFileTest()
        {
            CreatePresenter();
            _view.SaveRequested += Raise.EventWith(this, EventArgs.Empty);
            _dataStore.Received(1).Save();
        }
        
        [Test]
        public void EditorTextPassedToModel()
        {
            string text = "foo";
            _view.EditorText.Returns(text);
            CreatePresenter();
            _view.EditorTextChanged += Raise.EventWith(_view, EventArgs.Empty);
            _dataStore.Received(1).Text = text;
        }

        [Test]
        public void EditorTextPassedToView()
        {
            string text = "bar";
            _dataStore.Text.Returns(text);
            CreatePresenter();
            _dataStore.PropertyChanged += Raise.Event<PropertyChangedEventHandler>(
                _dataStore, new PropertyChangedEventArgs("Text"));
            _view.Received(1).EditorText = text;
        }

        [Test]
        public void CanSavePassedToView()
        {
            CreatePresenter();
            _dataStore.CanSave.Returns(true);
            _view.ClearReceivedCalls();
            _dataStore.PropertyChanged += Raise.Event<PropertyChangedEventHandler>(
                _dataStore, new PropertyChangedEventArgs("CanSave"));
            _view.Received(1).CanSave = true;
        }

        [Test]
        public void TextIsNotPassedBackToView()
        {
            CreatePresenter();
            _view.ClearReceivedCalls();
            _dataStore.When(x=>x.Text = Arg.Any<string>()).Do(x =>
            {
                _dataStore.PropertyChanged += Raise.Event<PropertyChangedEventHandler>(
                    _dataStore, new PropertyChangedEventArgs("Text"));
            });
            _view.EditorTextChanged += Raise.EventWith(_view, EventArgs.Empty);
            _view.Received(0).EditorText = Arg.Any<string>();
        }

        [Test]
        public void CanSaveIsPassedToViewAfterTextChange()
        {
            CreatePresenter();
            _view.ClearReceivedCalls();
            _dataStore.When(x => x.Text = Arg.Any<string>()).Do(x =>
            {
                _dataStore.PropertyChanged += Raise.Event<PropertyChangedEventHandler>(
                    _dataStore, new PropertyChangedEventArgs("Text"));
            });
            _view.EditorTextChanged += Raise.EventWith(_view, EventArgs.Empty);
            _view.Received(1).CanSave = Arg.Any<bool>();
        }
    }
}