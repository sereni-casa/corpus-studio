using System.Text;

namespace LingStudioWinFormsApp
{
    static class ExtensionClass
    {
        static bool mayBeUtf8Encoded(this byte[] encoded)
        {
            bool mayBe = true;
            int i = 0;
            while (mayBe && i < encoded.Length)
            {
                if (encoded[i] <= 0x7F) i++;
                else if (encoded[i] >= 0xC2 && encoded[i] <= 0xDF && i < encoded.Length - 1 && encoded[i + 1] >= 0x80 && encoded[i + 1] <= 0xBF) i += 2;
                else if (encoded[i] >= 0xE0 && encoded[i] <= 0xEF && i < encoded.Length - 2 && encoded[i + 1] >= 0x80 && encoded[i + 1] <= 0xBF && encoded[i + 2] >= 0x80 && encoded[i + 2] <= 0xBF && (encoded[i] != 0xE0 || encoded[i + 1] >= 0xA0) && (encoded[i] != 0xED || encoded[i + 1] <= 0x9F)) i += 3;
                else if (encoded[i] >= 0xF0 && encoded[i] <= 0xF4 && i < encoded.Length - 3 && encoded[i + 1] >= 0x80 && encoded[i + 1] <= 0xBF && encoded[i + 2] >= 0x80 && encoded[i + 2] <= 0xBF && encoded[i + 3] >= 0x80 && encoded[i + 3] <= 0xBF && (encoded[i] != 0xF0 || encoded[i + 1] >= 0x90) && (encoded[i] != 0xF4 || encoded[i + 1] <= 0x8F)) i += 4;
                else mayBe = false;
            }
            return mayBe;
        }

        static bool mayBeGbEncoded(this byte[] encoded)
        {
            bool mayBe = true;
            int i = 0;
            while (mayBe && i < encoded.Length)
            {
                if (encoded[i] <= 0x80) i++;
                else if (encoded[i] >= 0x81 && encoded[i] <= 0xFE && i < encoded.Length - 1 && encoded[i + 1] >= 0x40 && encoded[i + 1] != 0x7F && encoded[i + 1] <= 0xFE) i += 2;
                else if (encoded[i] >= 0x81 && encoded[i] <= 0xFE && i < encoded.Length - 3 && encoded[i + 1] >= 0x30 && encoded[i + 1] <= 0x39 && encoded[i + 2] >= 0x81 && encoded[i + 2] <= 0xFE && encoded[i + 3] >= 0x30 && encoded[i + 3] <= 0x39) i += 4;
                else mayBe = false;
            }
            return mayBe;
        }

        static string utf8Decode(this byte[] encoded) => new UTF8Encoding().GetString(encoded);

        static string gbDecode(this byte[] encoded) => Encoding.GetEncoding(54936).GetString(encoded);
    }
}
