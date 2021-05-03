using System;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace LingStudioWinFormsApp
{
    public partial class CorpusForm : Form
    {
        private string CorpusPath;
        private Corpus Corpus;
        private bool HasCorpusChanged;

        public void SetCorpusPath(string path) => CorpusPath = path;

        public CorpusForm(string corpusPath)
        {
            InitializeComponent();

            if (File.Exists(corpusPath))
            {
                Corpus = Corpus.FromJsonBytes(File.ReadAllBytes(corpusPath));
                textFileListView.BeginUpdate();
                foreach (var kvp in Corpus.TextFiles)
                {
                    textFileListView.Items.Add(new ListViewItem(new string[] { kvp.Key, Convert.ToBase64String(kvp.Value.Md5), kvp.Value.Encoding }));
                }
                textFileListView.EndUpdate();
                HasCorpusChanged = false;
            }
            else
            {
                Corpus = new Corpus();
                HasCorpusChanged = true;
            }
            CorpusPath = corpusPath;
        }

        private void addTextFileToolStripButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textFileListView.BeginUpdate();
                foreach (string path in openFileDialog.FileNames)
                {
                    if (Corpus.TextFiles.ContainsKey(path)) MessageBox.Show("文件已在语料库中：" + path);
                    else
                    {
                        byte[] file = null;
                        try
                        {
                            file = File.ReadAllBytes(path);
                            //md5 = new MD5CryptoServiceProvider().ComputeHash(File.OpenRead(path));
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("文件无法打开：" + path);
                            textFileListView.EndUpdate();
                        }
                        byte[] md5 = new MD5CryptoServiceProvider().ComputeHash(file);
                        string encoding = "?";
                        if (file.MayBeUtf8Encoded()) encoding = "UTF-8";
                        else if (file.MayBeGbEncoded()) encoding = "GB";

                        Corpus.TextFiles.Add(path, new TextFile(md5, encoding));
                        textFileListView.Items.Add(new ListViewItem(new string[] { path, Convert.ToBase64String(md5), encoding }));
                        HasCorpusChanged = true;
                    }
                }
                textFileListView.EndUpdate();
            }
        }

        private void removeTextFileToolStripButton_Click(object sender, EventArgs e)
        {
            if (textFileListView.SelectedItems.Count == 0) MessageBox.Show("未选择要移除的语料文件。");
            else
            {
                HasCorpusChanged = true;
                textFileListView.BeginUpdate();
                foreach (ListViewItem item in textFileListView.SelectedItems)
                {
                    Corpus.TextFiles.Remove(item.Text);
                    item.Remove();
                }
                textFileListView.EndUpdate();
            }
        }

        private void CorpusForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (HasCorpusChanged)
            {
                switch (MessageBox.Show("是否保存语料库？", "关闭语料库", MessageBoxButtons.YesNoCancel))
                {
                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                    case DialogResult.Yes:
                        try
                        {
                            File.WriteAllBytes(CorpusPath, Corpus.ToJsonBytes());
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("无法保存语料库。");
                            e.Cancel = true;
                        }
                        break;
                }
            }
        }

        private void textFileListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (textFileListView.SelectedItems.Count == 0)
            {
                removeTextFileToolStripButton.Enabled = false;
                md5ToolStripButton.Enabled = false;
            }
            else
            {
                removeTextFileToolStripButton.Enabled = true;
                md5ToolStripButton.Enabled = true;
            }
        }

        private void md5ToolStripButton_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in textFileListView.SelectedItems)
            {
                byte[] md5 = null;
                try
                {
                    md5 = new MD5CryptoServiceProvider().ComputeHash(File.OpenRead(item.Text));
                }
                catch (Exception)
                {
                    MessageBox.Show("文件无法打开：" + item.Text, "MD5 校验");
                }
                if (Convert.ToBase64String(md5) == Convert.ToBase64String(Corpus.TextFiles[item.Text].Md5))
                {
                    MessageBox.Show("校验成功：" + item.Text, "MD5 校验");
                }
                else if (MessageBox.Show("校验失败：" + item.Text + "\r\n原校验码：" + Convert.ToBase64String(Corpus.TextFiles[item.Text].Md5) + "\r\n新校验码：" + Convert.ToBase64String(md5) + "\r\n是否更新校验码？", "MD5 校验", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Corpus.TextFiles[item.Text].Md5 = md5;
                    HasCorpusChanged = true;
                }
            }
        }

        private void searchToolStripTextBox_TextChanged(object sender, EventArgs e) => searchToolStripButton.Enabled = searchToolStripTextBox.Text.Length > 0;

        private void searchToolStripButton_Click(object sender, EventArgs e)
        {
            searchListView.Items.Clear();
            searchListView.BeginUpdate();
            foreach (var kvp in Corpus.TextFiles)
            {
                if (kvp.Value.Encoding != "?")
                {
                    byte[] file = null;
                    try
                    {
                        file = File.ReadAllBytes(kvp.Key);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("无法打开文件：" + kvp.Key);
                    }
                    string text = "";
                    if (kvp.Value.Encoding == "UTF-8") text = file.Utf8Decode();
                    else if (kvp.Value.Encoding == "GB") text = file.GbDecode();
                    int i = -1;
                    string keyword = searchToolStripTextBox.Text;
                    while ((i = text.IndexOf(keyword, i + 1)) != -1)
                    {
                        int left = Math.Max(i - 20, 0);
                        int right = Math.Min(i + keyword.Length + 20, text.Length);
                        searchListView.Items.Add(new ListViewItem(new string[] { text[left..i], keyword, text[(i + keyword.Length)..right], kvp.Key }));
                    }
                }
            }
            searchListView.EndUpdate();
            MessageBox.Show("检索完毕。");
        }
    }
}
