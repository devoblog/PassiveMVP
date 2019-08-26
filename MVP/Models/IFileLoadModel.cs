using System;

namespace MVP.Models
{
    public interface  IFileLoadModel
    {
        event EventHandler Validated;

        bool IsValid { get; }
        string FileName { get; set; }

        void LoadFile();
    }
}
