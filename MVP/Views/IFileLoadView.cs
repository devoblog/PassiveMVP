using System;

namespace MVP.Views
{
    public interface IFileLoadView
    {
        event EventHandler FileNameChanged;

        string FileName { get; set; }
        bool IsValid { set; }
    }
}
