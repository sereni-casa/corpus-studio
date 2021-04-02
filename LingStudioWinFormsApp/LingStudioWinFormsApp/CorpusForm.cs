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
                //corpus = Corpus.FromJsonString(File.ReadAllText(corpusPath));
                Corpus = Corpus.FromJsonBytes(File.ReadAllBytes(corpusPath));
                textFileListBox.BeginUpdate();
                foreach (string path in Corpus.TextFiles.Keys)
                {
                    textFileListBox.Items.Add(path);
                }
                textFileListBox.EndUpdate();
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
                textFileListBox.BeginUpdate();
                foreach (string path in openFileDialog.FileNames)
                {
                    if (Corpus.TextFiles.ContainsKey(path)) MessageBox.Show("文件已存在");
                    else
                    {
                        try
                        {
                            Corpus.TextFiles.Add(path, new MD5CryptoServiceProvider().ComputeHash(File.OpenRead(path)));
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("文件无法打开");
                            textFileListBox.EndUpdate();
                        }
                        textFileListBox.Items.Add(path);
                        HasCorpusChanged = true;
                    }
                }
                textFileListBox.EndUpdate();
            }
        }

        private void removeTextFileToolStripButton_Click(object sender, EventArgs e)
        {
            if (textFileListBox.SelectedItems.Count == 0) MessageBox.Show("未选择要移除的语料文件");
            else
            {
                HasCorpusChanged = true;
                foreach (string item in textFileListBox.SelectedItems)
                {
                    Corpus.TextFiles.Remove(item);
                    //textFileListBox.SelectedItems.Remove(item);
                }
                textFileListBox.BeginUpdate();
                textFileListBox.Items.Clear();
                foreach (string path in Corpus.TextFiles.Keys)
                {
                    textFileListBox.Items.Add(path);
                }
                textFileListBox.EndUpdate();
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
    }
}
