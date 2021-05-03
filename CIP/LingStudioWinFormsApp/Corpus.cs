using System.Collections.Generic;
using System.Text.Json;

namespace LingStudioWinFormsApp
{
    class Corpus
    {

        public Dictionary<string, TextFile> TextFiles { get; set; }

        public static Corpus FromJsonString(string jsonString) => JsonSerializer.Deserialize<Corpus>(jsonString);

        public static Corpus FromJsonBytes(byte[] jsonBytes) => JsonSerializer.Deserialize<Corpus>(jsonBytes);

        public Corpus()
        {
            TextFiles = new();
        }

        public string ToJsonString() => JsonSerializer.Serialize(this);

        public byte[] ToJsonBytes() => JsonSerializer.SerializeToUtf8Bytes(this);
    }
}
