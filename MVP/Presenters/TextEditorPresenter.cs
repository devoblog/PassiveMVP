using System;
using MVP.Models;
using MVP.Views;

namespace MVP.Presenters
{
    public class TextEditorPresenter : Presenter<ITextEditorView, ITextEditorModel>
    {
        public TextEditorPresenter(ITextEditorView view, ITextEditorModel model)
            : base(view, model)
        {
        }

        protected override void HookViewEvents()
        {
            base.HookViewEvents();

            _view.FileTextChanged += ViewOnTextChanged;
        }

        protected override void UnhookViewEvents()
        {
            base.UnhookViewEvents();

            _view.FileTextChanged -= ViewOnTextChanged;
        }

        protected override void HookModelEvents()
        {
            base.HookModelEvents();

            _model.Updated += ModelOnUpdated;
        }

        protected override void UnhookModelEvents()
        {
            base.UnhookModelEvents();

            _model.Updated -= ModelOnUpdated;
        }

        private void ViewOnTextChanged(object sender, EventArgs e)
        {
            ModelAction(() => _model.Text = _view.FileText);
        }

        private void ModelOnUpdated(object sender, EventArgs e)
        {
            ViewAction(() => _view.FileText = _model.Text);
        }
    }
}