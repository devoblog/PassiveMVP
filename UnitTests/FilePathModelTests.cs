using MVP.Models;
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
}