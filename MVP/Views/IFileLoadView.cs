using System;

namespace MVP.Views
{
    public interface IFileLoadView
    {
        event EventHandler FileNameChanged;
        event EventHandler LoadFile;

        string FileName { get; set; }
        bool IsValid { set; }
    }
}
