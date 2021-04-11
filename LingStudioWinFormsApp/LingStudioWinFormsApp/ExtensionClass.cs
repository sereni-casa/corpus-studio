using System.Text;

namespace LingStudioWinFormsApp
{
    static class ExtensionClass
    {
        static bool MayBeUtf8Encoded(this byte[] encoded)
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

        static bool MayBeGbEncoded(this byte[] encoded)
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

        public static string Utf8Decode(this byte[] encoded) => new UTF8Encoding().GetString(encoded);

        static string GbDecode(this byte[] encoded) => Encoding.GetEncoding(54936).GetString(encoded);

        // https://www.unicode.org/charts/unihangridindex.html
        static bool IsHan(this Rune rune) => rune.Value is (>= 0x3400 and <= 0x4dbf) or (>= 0x4e00 and <= 0x9ffc) or (>= 0xf900 and <= 0xfad9) or (>= 0x20000 and <= 0x2a6dd) or (>= 0x2a700 and <= 0x2b734) or (>= 0x2b740 and <= 0x2b81d) or (>= 0x2b820 and <= 0x2cea1) or (>= 0x2ceb0 and <= 0x2ebe0) or (>= 0x2f800 and <= 0x2fa1d) or (>= 0x30000 and <= 0x3134a);

    }
}
