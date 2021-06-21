using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;

namespace CorpusStudio
{
    public class CorpusInfo : INotifyPropertyChanged
    {
        private bool unsaved;

        public string FilePath { get; set; }
        public Corpus Corpus { get; set; }

        public bool Unsaved 
        { 
            get => unsaved;
            set
            {
                if (unsaved != value)
                {
                    unsaved = value;
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(Unsaved)));
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(Name)));
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(SaveStatus)));
                }
            }
        }

        public string Name => Path.GetFileName(FilePath) + (Unsaved ? "*" : "");

        public string SaveStatus => Unsaved ? "未保存" : "已保存";

        public ObservableCollection<TextFile> SelectedTextFiles { get; set; } = new();


        public event PropertyChangedEventHandler PropertyChanged;
    }
}
