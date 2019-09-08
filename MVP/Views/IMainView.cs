using System;

namespace MVP.Views
{
    public interface IMainView
    {
        event EventHandler FileNameChanged;
        event EventHandler EditorTextChanged;
        event EventHandler LoadRequested;
        event EventHandler SaveRequested;

        string FileName { get; set; }
        bool FileNameIsValid { set; }
        
        string EditorText { get; set; }

        bool CanSave { set; }
    }
}
