using System.Collections.ObjectModel;
using System.ComponentModel;

namespace CorpusStudio
{
    public class MainWindowResources : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<CorpusInfo> CorpusCollection { get; set; } = new();

        private CorpusInfo selectedCorpus;

        public CorpusInfo SelectedCorpus
        {
            get => selectedCorpus;
            set
            {
                if (selectedCorpus != value)
                {
                    selectedCorpus = value;
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(SelectedCorpus)));
                }
            }
        }

    }
}
