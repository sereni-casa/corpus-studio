using System.ComponentModel;
using System.IO;

namespace CorpusStudio
{
    public class CorpusInfo : INotifyPropertyChanged
    {
        private bool unsaved;

        public CorpusInfo(bool unsaved) => this.unsaved = unsaved;

        public string FilePath { get; set; }
        public Corpus Corpus { get; set; }

        public bool Unsaved
        {
            get => unsaved;
            set
            {
                unsaved = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Unsaved)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SaveStatus)));
            }
        }

        public string Name => Path.GetFileName(FilePath) + (Unsaved ? "*" : "");

        public string SaveStatus => Unsaved ? "未保存" : "已保存";

        public string CountMinLen
        {
            get => countMinLen;
            set
            {
                countMinLen = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CountMinLen)));
            }
        }

        public string CountMaxLen
        {
            get => countMaxLen;
            set
            {
                countMaxLen = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CountMaxLen)));
            }
        }

        public string CountMinFreq
        {
            get => countMinFreq;
            set
            {
                countMinFreq = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CountMinFreq)));
            }
        }

        public bool CountHanOnly
        {
            get => countHanOnly;
            set
            {
                countHanOnly = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CountHanOnly)));
            }
        }

        public string SearchLeftLen
        {
            get => searchLeftLen;
            set
            {
                searchLeftLen = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SearchLeftLen)));
            }
        }

        public string SearchRightLen
        {
            get => searchRightLen;
            set
            {
                searchRightLen = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SearchRightLen)));
            }
        }

        public int SearchMode
        {
            get => searchMode;
            set
            {
                searchMode = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SearchMode)));
            }
        }

        public string SearchContent
        {
            get => searchContent;
            set
            {
                searchContent = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SearchContent)));
            }
        }

        private string countMinLen = "2";
        private string countMaxLen = "4";
        private string countMinFreq = "100";
        private bool countHanOnly = true;
        private string searchLeftLen = "20";
        private string searchRightLen = "20";
        private int searchMode;
        private string searchContent = "的";

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
