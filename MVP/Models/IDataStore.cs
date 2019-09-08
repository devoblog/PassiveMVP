using System.ComponentModel;

namespace MVP.Models
{
    public interface IDataStore : INotifyPropertyChanged
    {
        string FileName { get; set; }
        bool FileNameIsValid { get; }

        string Text { get; set; }

        void Load();
        void Save();

        bool CanSave { get; }
    }
}