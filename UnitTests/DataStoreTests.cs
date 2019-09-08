using MVP.Models;
using NSubstitute;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class DataStoreTests
    {
        private IDataStore _dataStore;
        private IFileSystemWrapper _fileSystemWrapper;

        [SetUp]
        public void SetUp()
        {
            _fileSystemWrapper = Substitute.For<IFileSystemWrapper>();
            _dataStore = new DataStore(_fileSystemWrapper);
        }

        [Test]
        public void TextChangeRaisesEvent()
        {
            int counter = 0;
            _dataStore.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == "Text")
                    counter++;
            };
            _dataStore.Text = "blah";
            Assert.AreEqual(1, counter);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void IsValidIfFileExists(bool fileExists)
        {
            _fileSystemWrapper.FileExists(Arg.Any<string>()).Returns(fileExists);
            _dataStore.FileName = "a";
            Assert.AreEqual(fileExists, _dataStore.FileNameIsValid);
        }

        [Test]
        public void LoadTest()
        {
            _fileSystemWrapper.ReadTextFile(Arg.Any<string>()).Returns("MyText");
            _dataStore.Load();
            Assert.AreEqual("MyText", _dataStore.Text);
        }

        [Test]
        public void SaveTest()
        {
            string fileName = "MyFileName";
            string text = "MyText";
            _dataStore.FileName = fileName;
            _dataStore.Text = text;
            _dataStore.Save();
            _fileSystemWrapper.Received(1).SaveFile(fileName, text);
        }

        [Test]
        public void CanSaveTrueAfterTextEdited()
        {
            _dataStore.Text = "foo";
            Assert.IsTrue(_dataStore.CanSave);
        }

        [Test]
        public void CanSaveFalseAfterLoad()
        {
            _dataStore.Text = "foo";
            _dataStore.Load();
            Assert.IsFalse(_dataStore.CanSave);
        }

        [Test]
        public void CanSaveFalseAfterSave()
        {
            _dataStore.Text = "foo";
            _dataStore.Save();
            Assert.IsFalse(_dataStore.CanSave);
        }
    }
}