using System;
using MVP.Models;
using MVP.Presenters;
using MVP.Views;
using NSubstitute;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class TextEditorPresenterTests
    {
        private ITextEditorView _view;
        private ITextEditorModel _model;

        [SetUp]
        public void SetUp()
        {
            _view = Substitute.For<ITextEditorView>();
            _model = Substitute.For<ITextEditorModel>();
            new TextEditorPresenter(_view, _model);
        }


        [Test]
        public void ModelTextPassedToViewTest()
        {
            string text = "MyText";
            _model.Text.Returns(text);
            _model.Updated += Raise.EventWith(_model, EventArgs.Empty);
            _view.Received(1).FileText = text;
        }

        [Test]
        public void ViewTextPassedToModelTest()
        {
            string text = "MyText";
            _view.FileText.Returns(text);
            _view.FileTextChanged += Raise.EventWith(_view, EventArgs.Empty);
            _model.Received(1).Text = text;
        }
    }
}