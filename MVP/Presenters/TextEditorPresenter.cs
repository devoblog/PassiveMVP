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

        private void ModelOnUpdated(object sender, EventArgs e)
        {
            _view.FileText = _model.Text;
        }
    }
}