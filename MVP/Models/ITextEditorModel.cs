using System;

namespace MVP.Models
{
    public interface ITextEditorModel
    {
        event EventHandler Updated;

        string Text { get; set; }
    }
}