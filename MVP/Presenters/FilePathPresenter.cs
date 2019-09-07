using System;
using MVP.Models;
using MVP.Views;

namespace MVP.Presenters
{
    public class FilePathPresenter : Presenter<IFilePathView, IFilePathModel>
    {
        public FilePathPresenter(IFilePathView view, IFilePathModel model) : base(view, model)
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

        private void ViewOnFileNameChanged(object sender, EventArgs e)
        {
            _model.FileName = _view.FileName;
        }
    }
}