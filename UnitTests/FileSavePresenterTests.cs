using System;
using MVP.Models;
using MVP.Presenters;
using MVP.Views;
using NSubstitute;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class FileSavePresenterTests
    {
        private IFileSaveView _view;
        private IFileSaveModel _model;

        [SetUp]
        public void SetUp()
        {
            _view = Substitute.For<IFileSaveView>();
            _model = Substitute.For<IFileSaveModel>();
            new FileSavePresenter(_view, _model);
        }

        [Test]
        public void SaveFileTest()
        {
            _view.SaveFile += Raise.EventWith(this, EventArgs.Empty);
            _model.Received(1).SaveFile();
        }
    }
}