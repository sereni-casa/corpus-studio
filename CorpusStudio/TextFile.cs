using System;
using System.ComponentModel;
using System.IO;

namespace CorpusStudio
{
    public class TextFile : INotifyPropertyChanged
    {
        private string encoding;

        public string Path { get; set; }
        public byte[] Md5 { get; set; }
        public string Encoding
        {
            get => encoding;
            set
            {
                if (encoding != value)
                {
                    encoding = value;
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(Encoding)));
                }
            }
        }

        public TextFile(string path, string encoding)
        {
            Path = path;
            this.encoding = encoding;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public byte[] GetBytes()
        {
            byte[] file;
            try
            {
                file = File.ReadAllBytes(Path);
            }
            catch (Exception)
            {
                return null;
            }
            return file;
        }

        public string GetText() => Encoding switch
        {
            "UTF-8" => GetBytes().Utf8Decode(),
            "GB" => GetBytes().GbDecode(),
            _ => null
        };

        public bool MayBeUtf8Encoded() => GetBytes().MayBeUtf8Encoded();

        public bool MayBeGbEncoded() => GetBytes().MayBeGbEncoded();
    }
}
