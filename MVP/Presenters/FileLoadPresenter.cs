using System;
using MVP.Models;
using MVP.Views;

namespace MVP.Presenters
{
    public class FileLoadPresenter : Presenter<IFileLoadView, IFileLoadModel>
    {
        public FileLoadPresenter(IFileLoadView view, IFileLoadModel model)
            : base(view, model)
        {
        }

        protected override void HookViewEvents()
        {
            base.HookViewEvents();

            _view.FileNameChanged += ViewOnFileNameChanged;
        }

        protected override void UnhookViewEvents()
        {
            base.UnhookViewEvents();

            _view.FileNameChanged -= ViewOnFileNameChanged;
        }

        protected override void HookModelEvents()
        {
            base.HookModelEvents();

            _model.Validated += ModelOnValidated;
        }

        protected override void UnhookModelEvents()
        {
            base.UnhookModelEvents();

            _model.Validated -= ModelOnValidated;
        }

        private void ViewOnFileNameChanged(object sender, EventArgs e)
        {
            _model.FileName = _view.FileName;
        }

        private void ModelOnValidated(object sender, EventArgs e)
        {
            _view.IsValid = _model.IsValid;
        }
    }
}
