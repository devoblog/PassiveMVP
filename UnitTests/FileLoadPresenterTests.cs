﻿using System;
using MVP.Models;
using MVP.Presenters;
using MVP.Views;
using NSubstitute;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class FileLoadPresenterTests
    {
        private IFileLoadView _view;
        private IFileLoadModel _model;

        [SetUp]
        public void SetUp()
        {
            _view = Substitute.For<IFileLoadView>();
            _model = Substitute.For<IFileLoadModel>();
        }

        private void CreatePresenter()
        {
            new FileLoadPresenter(_view, _model);
        }

        [Test]
        public void InitialIsValidPassedToModel()
        {
            _model.IsValid.Returns(false);
            CreatePresenter();
            _view.Received(1).IsValid = false;
        }


        [Test]
        public void LoadFileRequestPassedToModel()
        {
            CreatePresenter();
            _view.LoadFile += Raise.EventWith(_view, EventArgs.Empty);
            _model.Received(1).LoadFile();
        }

        [TestCase(true)]
        [TestCase(false)]
        public void IsValidPassedToViewTest(bool isValid)
        {
            _model.IsValid.Returns(isValid);
            CreatePresenter();
            _view.ClearReceivedCalls();
            _model.Validated += Raise.EventWith(_model, EventArgs.Empty);
            _view.Received(1).IsValid = isValid;
        }
    }
}