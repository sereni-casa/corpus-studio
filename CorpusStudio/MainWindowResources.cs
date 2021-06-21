using System.Collections.ObjectModel;
using System.ComponentModel;

namespace CorpusStudio
{
    public class MainWindowResources : INotifyPropertyChanged
    {
        private CorpusInfo selectedCorpus;

        public ObservableCollection<CorpusInfo> CorpusCollection { get; set; } = new();

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

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
