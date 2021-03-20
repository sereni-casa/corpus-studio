using System.ComponentModel;

namespace CorpusStudio
{
    public class NgramOptions : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string minLength = "2";
        private string maxLength = "4";
        private string minFreq = "10";
        private bool hanOnly = true;
        private bool valid = true;

        private void Validate() => Valid = int.TryParse(MinLength, out int _minLength) && int.TryParse(MaxLength, out int _maxLength) && int.TryParse(MinFreq, out int _minFreq) && _minLength > 0 && _minLength <= _maxLength && _minFreq > 0;

        public string MinLength
        {
            get => minLength; set
            {
                if (MinLength != value)
                {
                    minLength = value;
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(MinLength)));
                    Validate();
                }
            }
        }

        public string MaxLength
        {
            get => maxLength; set
            {
                if (MaxLength != value)
                {
                    maxLength = value;
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(MaxLength)));
                    Validate();
                }
            }
        }

        public string MinFreq
        {
            get => minFreq; set
            {
                if (MinFreq != value)
                {
                    minFreq = value;
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(MinFreq)));
                    Validate();
                }
            }
        }

        public bool HanOnly
        {
            get => hanOnly; set
            {
                if (HanOnly != value)
                {
                    hanOnly = value;
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(HanOnly)));
                }
            }
        }

        public bool Valid
        {
            get => valid; set
            {
                if (Valid != value)
                {
                    valid = value;
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(Valid)));
                }
            }
        }

        public NgramOptions()
        {

        }

    }
}
