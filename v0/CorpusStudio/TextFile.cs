namespace LingStudioWinFormsApp
{
    class TextFile
    {
        public byte[] Md5 { get; set; }

        public string Encoding { get; set; }

        public TextFile(byte[] md5, string encoding)
        {
            Md5 = md5;
            Encoding = encoding;
        }
    }
}
