using System;
using System.IO;

namespace CIPLib
{
    public class TextFile
    {
        public string Path { get; set; }
        public byte[] Md5 { get; set; }
        public string Encoding { get; set; }

        public TextFile() { }

        public TextFile(string path, byte[] md5, string encoding)
        {
            Path = path;
            Md5 = md5;
            Encoding = encoding;
        }

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
