using System;

namespace MVP.Views
{
    public interface ITextView
    {
        event EventHandler TextUpdated;

        string Text { get; set; }
    }

    public interface IFileNameView : ITextView
    {
    }

    public interface ITextEditorView : ITextView
    {
    }
}