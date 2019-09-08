using System;
using System.ComponentModel;
using MVP.Models;
using MVP.Views;

namespace MVP.Presenters
{
    public class MainPresenter : Presenter<IMainView, IDataStore>
    {
        public MainPresenter(IMainView view, IDataStore model) : base(view, model)
        {
        }

        protected override void SetInitialState()
        {
            base.SetInitialState();

            _view.FileNameIsValid = _model.FileNameIsValid;
        }

        protected override void HookViewEvents()
        {
            base.HookViewEvents();

            _view.FileNameChanged += ViewOnFileNameChanged;
            _view.EditorTextChanged += ViewOnEditorTextChanged;
            _view.LoadRequested += ViewOnLoadRequested;
            _view.SaveRequested += ViewOnSaveRequested;
        }

        protected override void UnhookViewEvents()
        {
            base.UnhookViewEvents();

            _view.FileNameChanged -= ViewOnFileNameChanged;
            _view.EditorTextChanged -= ViewOnEditorTextChanged;
            _view.LoadRequested -= ViewOnLoadRequested;
            _view.SaveRequested -= ViewOnSaveRequested;
        }

        protected override void HookModelEvents()
        {
            base.HookModelEvents();

            _model.PropertyChanged += ModelOnPropertyChanged;
        }

        protected override void UnhookModelEvents()
        {
            base.UnhookModelEvents();

            _model.PropertyChanged -= ModelOnPropertyChanged;
        }

        private void ViewOnFileNameChanged(object sender, EventArgs e)
        {
            _model.FileName = _view.FileName;
        }

        private void ViewOnEditorTextChanged(object sender, EventArgs e)
        {
            ModelAction(() => _model.Text = _view.EditorText);
        }

        private void ViewOnLoadRequested(object sender, EventArgs e)
        {
            _model.Load();
        }

        private void ViewOnSaveRequested(object sender, EventArgs e)
        {
            _model.Save();
        }

        private void ModelOnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "FileNameIsValid":
                    _view.FileNameIsValid = _model.FileNameIsValid;
                    break;
                case "Text":
                    ViewAction(() => _view.EditorText = _model.Text);
                    break;
            }
        }
    }
}