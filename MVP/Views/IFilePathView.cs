using System;

namespace MVP.Views
{
    public interface IFilePathView
    {
        event EventHandler FileNameChanged;

        string FileName { get; set; }
    }
}