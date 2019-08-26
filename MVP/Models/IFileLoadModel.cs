using System;
using System.Xml;

namespace MVP.Models
{
    public interface  IFileLoadModel
    {
        event EventHandler Validated;

        bool IsValid { get; }
        string FileName { get; set; }
    }
}
