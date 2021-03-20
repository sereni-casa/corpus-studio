using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace CorpusStudio
{
    public class OutputWindowData : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private bool isReadOnly = true;
        private ObservableCollection<object> dataToOutput = new();

        public OutputWindowData() { }

        public OutputWindowData(string name) => Name = name;

        public string Title { get => $"Corpus Stuidio 输出：{Name}"; }

        public string Name { get; set; }

        public ObservableCollection<object> DataToOutput
        {
            get => dataToOutput; set
            {
                dataToOutput = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DataToOutput)));
            }
        }

        public bool IsReadOnly
        {
            get => isReadOnly; set
            {
                isReadOnly = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsReadOnly)));
            }
        }
    }
}
