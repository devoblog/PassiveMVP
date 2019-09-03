using System;

namespace MVP.Models
{
    public class TextEditorModel : ITextEditorModel
    {
        private string _text;
        public event EventHandler Updated;

        public string Text
        {
            get => _text;
            set
            {
                _text = value;
                Updated?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}