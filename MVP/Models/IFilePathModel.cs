using System;

namespace MVP.Models
{
    public interface IFilePathModel
    {
        event EventHandler FileNameChanged;

        string FileName { get; set; }
    }
}