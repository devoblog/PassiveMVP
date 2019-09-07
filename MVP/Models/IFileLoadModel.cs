using System;

namespace MVP.Models
{
    public interface  IFileLoadModel
    {
        event EventHandler Validated;

        bool IsValid { get; }

        void LoadFile();
    }
}
