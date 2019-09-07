using MVP.Models;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class TextEditorModelTests
    {
        [Test]
        public void ModelUpdatedOnTextChange()
        {
            int counter = 0;
            TextEditorModel model = new TextEditorModel();
            model.Updated += (sender, args) => counter++;
            model.Text = "blah";
            Assert.AreEqual(1, counter);
        }
    }
}