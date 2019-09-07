using System;
using MVP.Models;
using MVP.Views;

namespace MVP.Presenters
{
    public class FileSavePresenter : Presenter<IFileSaveView, IFileSaveModel>
    {
        public FileSavePresenter(IFileSaveView view, IFileSaveModel model) 
            : base(view, model)
        {
        }

        protected override void HookModelEvents()
        {
            base.HookModelEvents();

            _view.SaveFile += ViewOnSaveFile;
        }

        protected override void UnhookViewEvents()
        {
            base.UnhookViewEvents();

            _view.SaveFile -= ViewOnSaveFile;
        }
        
        private void ViewOnSaveFile(object sender, EventArgs e)
        {
            _model.SaveFile();
        }
    }
}