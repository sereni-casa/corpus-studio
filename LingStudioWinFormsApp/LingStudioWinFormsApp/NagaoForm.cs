using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace LingStudioWinFormsApp
{
    public partial class NagaoForm : Form
    {
        int[] p, l;
        string corpus = "";

        public NagaoForm()
        {
            InitializeComponent();
        }

        private void clearCorpusToolStripButton_Click(object sender, EventArgs e)
        {
            corpus = "";
            corpusTextBox.Clear();
        }

        private void addCorpusFromFileToolStripButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                taskToolStripStatusLabel.Text = "正在读入文件";
                Application.DoEvents();
                corpus += "";
                foreach (string filePath in openFileDialog.FileNames) corpus += File.ReadAllText(filePath);
                corpusTextBox.Text = corpus;
                taskToolStripStatusLabel.Text = "空闲";
            }
        }

        private void generateListToolStripButton_Click(object sender, EventArgs e)
        {
            taskToolStripStatusLabel.Text = "正在生成 P 表";
            Application.DoEvents();
            var time1 =  DateTime.Now;
            p = new int[corpus.Length];
            for (int i = 0; i < corpus.Length; i++) p[i] = i;
            Array.Sort(p, new Comparison<int>((x, y) =>
            {
                int i = 0;
                while (true)
                {
                    if (x + i == corpus.Length) return -1;
                    if (y + i == corpus.Length) return 1;
                    if (corpus[x + i] < corpus[y + i]) return -1;
                    if (corpus[x + i] > corpus[y + i]) return 1;
                    i++;
                }
            }
            ));
            var time2 = DateTime.Now;
            var time = time2 - time1;
            taskToolStripStatusLabel.Text = "生成 P 表用时 " + time.TotalMilliseconds + " 毫秒";
            Application.DoEvents();

            l = new int[corpus.Length];
            l[0] = 0;
            for (int i = 1; i < corpus.Length; i++)
            {
                int j = 0;
                while (p[i - 1] + j < corpus.Length && p[i] + j < corpus.Length && corpus[p[i - 1] + j] == corpus[p[i] + j]) j++;
                l[i] = j;
            }
            if (MessageBox.Show("是否显示列表？", "生成列表", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                listListView.BeginUpdate();
                for (int i = 0; i < corpus.Length; i++)
                {
                    ListViewItem item = new(i.ToString());
                    item.SubItems.Add(p[i].ToString());
                    item.SubItems.Add(l[i].ToString());
                    //item.SubItems.Add(corpus[p[i]..]);
                    listListView.Items.Add(item);
                }
                listListView.EndUpdate();
            }
        }

        private void clearListToolStripButton_Click(object sender, EventArgs e)
        {
            listListView.Items.Clear();
        }

        private void minLengthNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            maxLengthNumericUpDown.Minimum = minLengthNumericUpDown.Value;
        }

        private void maxLengthNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            minLengthNumericUpDown.Maximum = maxLengthNumericUpDown.Value;
        }

        private void corpusTextBox_TextChanged(object sender, EventArgs e)
        {
            corpus = corpusTextBox.Text;
        }

        private void calcButton_Click(object sender, EventArgs e)
        {
            resultListView.Items.Clear();
            if (p != null && l != null)
            {
                int minLength = (int)minLengthNumericUpDown.Value;
                int maxLength = (int)maxLengthNumericUpDown.Value;
                int minFreq = (int)minFreqNumericUpDown.Value;
                Dictionary<int, Dictionary<int, int>> ngram = new();
                for (int n = minLength; n <= maxLength; n++)
                {
                    ngram.Add(n, new Dictionary<int, int>());
                    int p0 = -1;
                    for (int i = 1; i < corpus.Length; i++)
                    {
                        if (l[i] >= n)
                        {
                            if (l[i - 1] < n)
                            {
                                p0 = p[i];
                                ngram[n].Add(p0, 1);
                            }
                            else ngram[n][p0]++;
                        }
                    }
                }

                resultListView.BeginUpdate();
                for (int n = minLength; n <= maxLength; n++)
                {
                    for (int i = 0; i < corpus.Length; i++)
                    {
                        if (ngram[n].ContainsKey(p[i]) && ngram[n][p[i]] >= minFreq)
                        {
                            string substring = corpus.Substring(p[i], n);
                            bool hanOnly = true;
                            if (hanOnlyCheckBox.Checked)
                            {
                                int j = 0;
                                while (hanOnly && j < substring.Length)
                                {
                                    if (substring[j] is (not >= '\u3400' or not <= '\u4dbf') and (not >= '\u4e00' or not <= '\u9ffc')) hanOnly = false;
                                    j++;
                                }
                            }
                            if (hanOnly)
                            {
                                ListViewItem item = new(p[i].ToString());
                                item.SubItems.Add(ngram[n][p[i]].ToString());
                                item.SubItems.Add(substring);
                                resultListView.Items.Add(item);
                            }
                        }
                    }
                }
                resultListView.EndUpdate();
            }
        }
    }
}
