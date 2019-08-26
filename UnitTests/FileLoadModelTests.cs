﻿using MVP.Models;
using NSubstitute;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class FileLoadModelTests
    {
        private IFileSystemWrapper _fileSystemWrapper;

        [SetUp]
        public void SetUp()
        {
            _fileSystemWrapper = Substitute.For<IFileSystemWrapper>();
        }

        [TestCase(true)]
        [TestCase(false)]
        public void ModelIsValidIfFileExists(bool fileExists)
        {
            _fileSystemWrapper.FileExists(Arg.Any<string>()).Returns(fileExists);
            IFileLoadModel model = new FileLoadModel(_fileSystemWrapper);
            model.FileName = "MyFile.txt";
            Assert.AreEqual(fileExists, model.IsValid);
        }

        [Test]
        public void ValidatedEventRaisedWhenFileNameChanges()
        {
            int counter = 0;
            IFileLoadModel model = new FileLoadModel(_fileSystemWrapper);
            model.Validated += (sender, args) => counter++;
            model.FileName = "MyFile.txt";
            Assert.AreEqual(1, counter);
        }
    }
}