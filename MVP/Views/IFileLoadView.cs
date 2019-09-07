using System;

namespace MVP.Views
{
    public interface IFileLoadView
    {
        event EventHandler LoadFile;
        
        bool IsValid { set; }
    }
}
