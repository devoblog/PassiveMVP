using System;

namespace MVP.Views
{
    public interface ITextEditorView
    {
        event EventHandler FileTextChanged;

        string FileText { get; set; }
    }
}