using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace LingStudioWinFormsApp
{
    public partial class Form1 : Form
    {
        private string folder;
        private byte[] fileBytes;
        private int[] byteIndexOfUtf8CharAt;
        private int[] byteIndexOfGbCharAt;
        private int[] utf8CharIndexOfByteAt;
        private int[] gbCharIndexOfByteAt;
        private bool mayBeUtf8;
        private bool mayBeGb;
        private bool ignoreSelectionChanged = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void folderPanelToolStripButton_CheckedChanged(object sender, EventArgs e)
        {
            splitContainer1.Panel1Collapsed = !folderPanelToolStripButton.Checked;
        }

        private void consolePanelToolStripButton_CheckedChanged(object sender, EventArgs e)
        {
            splitContainer2.Panel2Collapsed = !consolePanelToolStripButton.Checked;
        }

        private void chooseFolderToolStripButton_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                folder = folderBrowserDialog1.SelectedPath;
                folderToolStripStatusLabel.Text = folder;
                fileToolStripStatusLabel.Text = "无";
                richTextBox1.Clear();
                treeView1.BeginUpdate();
                treeView1.Nodes.Clear();
                TreeNode folderNode = treeView1.Nodes.Add(folder, Path.GetFileName(folder));
                Queue<string> queue = new();
                Dictionary<string, TreeNode> parentNodes = new();
                foreach (string child in Directory.GetFileSystemEntries(folder))
                {
                    queue.Enqueue(child);
                    parentNodes[child] = folderNode;
                }
                while (queue.Count > 0)
                {
                    string current = queue.Dequeue();
                    TreeNode currentNode = parentNodes[current].Nodes.Add(current, Path.GetFileName(current));
                    if (File.GetAttributes(current).HasFlag(FileAttributes.Directory))
                        foreach (string child in Directory.GetFileSystemEntries(current))
                        {
                            queue.Enqueue(child);
                            parentNodes[child] = currentNode;
                        }
                }
                treeView1.EndUpdate();
            }
        }

        private void treeView1_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            e.Cancel = File.GetAttributes(e.Node.Name).HasFlag(FileAttributes.Directory);
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            fileToolStripStatusLabel.Text = e.Node.Name;
            fileBytes = File.ReadAllBytes(e.Node.Name);
            ChooseBaseN(2);
            
            int i, j;

            // May encoding be utf8?
            mayBeUtf8 = true;
            byteIndexOfUtf8CharAt = new int[fileBytes.Length];
            utf8CharIndexOfByteAt = new int[fileBytes.Length];
            i = 0;
            j = 0;
            while (mayBeUtf8 && i < fileBytes.Length)
                if (fileBytes[i] <= 0x7F)
                {
                    utf8CharIndexOfByteAt[i] = j;
                    byteIndexOfUtf8CharAt[j] = i;
                    i++;
                    j++;
                }
                else if (fileBytes[i] >= 0xC2 && fileBytes[i] <= 0xDF
                    && i < fileBytes.Length - 1
                    && fileBytes[i + 1] >= 0x80 && fileBytes[i + 1] <= 0xBF)
                {
                    utf8CharIndexOfByteAt[i] = j;
                    utf8CharIndexOfByteAt[i + 1] = -j - 1;
                    byteIndexOfUtf8CharAt[j] = i;
                    i += 2;
                    j++;
                }
                else if (fileBytes[i] >= 0xE0 && fileBytes[i] <= 0xEF
                    && i < fileBytes.Length - 2
                    && fileBytes[i + 1] >= 0x80 && fileBytes[i + 1] <= 0xBF
                    && fileBytes[i + 2] >= 0x80 && fileBytes[i + 2] <= 0xBF
                    && (fileBytes[i] != 0xE0 || fileBytes[i + 1] >= 0xA0)
                    && (fileBytes[i] != 0xED || fileBytes[i + 1] <= 0x9F))
                {
                    utf8CharIndexOfByteAt[i] = j;
                    utf8CharIndexOfByteAt[i + 1] = -j - 1;
                    utf8CharIndexOfByteAt[i + 2] = -j - 1;
                    byteIndexOfUtf8CharAt[j] = i;
                    i += 3;
                    j++;
                }
                else if (fileBytes[i] >= 0xF0 && fileBytes[i] <= 0xF4
                    && i < fileBytes.Length - 3
                    && fileBytes[i + 1] >= 0x80 && fileBytes[i + 1] <= 0xBF
                    && fileBytes[i + 2] >= 0x80 && fileBytes[i + 2] <= 0xBF
                    && fileBytes[i + 3] >= 0x80 && fileBytes[i + 3] <= 0xBF
                    && (fileBytes[i] != 0xF0 || fileBytes[i + 1] >= 0x90)
                    && (fileBytes[i] != 0xF4 || fileBytes[i + 1] <= 0x8F))
                {
                    utf8CharIndexOfByteAt[i] = j;
                    utf8CharIndexOfByteAt[i + 1] = -j - 1;
                    utf8CharIndexOfByteAt[i + 2] = -j - 1;
                    utf8CharIndexOfByteAt[i + 3] = -j - 1;
                    byteIndexOfUtf8CharAt[j] = i;
                    i += 4;
                    j++;
                }
                else
                    mayBeUtf8 = false;

            // May encoding be gb(18030+0x80)?
            mayBeGb = true;
            byteIndexOfGbCharAt = new int[fileBytes.Length];
            gbCharIndexOfByteAt = new int[fileBytes.Length];
            i = 0;
            j = 0;
            while (mayBeGb && i < fileBytes.Length)
                if (fileBytes[i] <= 0x80)
                {
                    gbCharIndexOfByteAt[i] = j;
                    byteIndexOfGbCharAt[j] = i;
                    i++;
                    j++;
                }
                else if (fileBytes[i] >= 0x81 && fileBytes[i] <= 0xFE
                    && i < fileBytes.Length - 1
                    && fileBytes[i + 1] >= 0x40 && fileBytes[i + 1] != 0x7F && fileBytes[i + 1] <= 0xFE)
                {
                    gbCharIndexOfByteAt[i] = j;
                    gbCharIndexOfByteAt[i + 1] = -j - 1;
                    byteIndexOfGbCharAt[j] = i;
                    i += 2;
                    j++;
                }
                else if (fileBytes[i] >= 0x81 && fileBytes[i] <= 0xFE
                    && i < fileBytes.Length - 3
                    && fileBytes[i + 1] >= 0x30 && fileBytes[i + 1] <= 0x39
                    && fileBytes[i + 2] >= 0x81 && fileBytes[i + 2] <= 0xFE
                    && fileBytes[i + 3] >= 0x30 && fileBytes[i + 3] <= 0x39)
                {
                    gbCharIndexOfByteAt[i] = j;
                    gbCharIndexOfByteAt[i + 1] = -j - 1;
                    gbCharIndexOfByteAt[i + 2] = -j - 1;
                    gbCharIndexOfByteAt[i + 3] = -j - 1;
                    byteIndexOfGbCharAt[j] = i;
                    i += 4;
                    j++;
                }
                else
                    mayBeGb = false;
            
            utf8ToolStripButton.Enabled = mayBeUtf8;
            gbToolStripButton.Enabled = mayBeGb;
            if (mayBeUtf8)
                ChooseEncoding("utf8");
            else if (mayBeGb)
                ChooseEncoding("gb");
            else
                ChooseEncoding("");
        }

        private void ChooseBaseN(int baseN)
        {
            if (fileBytes != null)
            {
                binToolStripButton.Checked = false;
                octToolStripButton.Checked = false;
                decToolStripButton.Checked = false;
                hexToolStripButton.Checked = false;
                int width = 8;
                switch (baseN)
                {
                    case 2:
                        binToolStripButton.Checked = true;
                        break;
                    case 8:
                        octToolStripButton.Checked = true;
                        width = 4;
                        break;
                    case 10:
                        decToolStripButton.Checked = true;
                        width = 3;
                        break;
                    case 16:
                        hexToolStripButton.Checked = true;
                        width = 2;
                        break;
                }
                listBox1.BeginUpdate();
                listBox1.Items.Clear();
                foreach (byte fileByte in fileBytes)
                    listBox1.Items.Add(Convert.ToString(fileByte, baseN).PadLeft(width, '0'));
                listBox1.EndUpdate();
            }
        }

        private void binToolStripButton_Click(object sender, EventArgs e)
        {
            ChooseBaseN(2);
        }

        private void octToolStripButton_Click(object sender, EventArgs e)
        {
            ChooseBaseN(8);
        }

        private void decToolStripButton_Click(object sender, EventArgs e)
        {
            ChooseBaseN(10);
        }

        private void hexToolStripButton_Click(object sender, EventArgs e)
        {
            ChooseBaseN(16);
        }

        private void multiColumnToolStripButton_CheckedChanged(object sender, EventArgs e)
        {
            listBox1.MultiColumn = multiColumnToolStripButton.Checked;
        }

        private void utf8ToolStripButton_Click(object sender, EventArgs e)
        {
            ChooseEncoding("utf8");
        }

        private void gbToolStripButton_Click(object sender, EventArgs e)
        {
            ChooseEncoding("gb");
        }

        private void ChooseEncoding(string encoding)
        {
            if (fileBytes != null)
            {
                utf8ToolStripButton.Checked = false;
                gbToolStripButton.Checked = false;
                richTextBox1.Clear();
                if (encoding != "")
                    switch (encoding)
                    {
                        case "utf8":
                            utf8ToolStripButton.Checked = true;
                            UTF8Encoding utf8 = new();
                            richTextBox1.Text = utf8.GetString(fileBytes);
                            break;
                        case "gb":
                            gbToolStripButton.Checked = true;
                            Encoding gb = Encoding.GetEncoding(54936);
                            richTextBox1.Text = gb.GetString(fileBytes);
                            break;
                    }
            }
        }

        private bool EncodingMayBe(byte[] bytes, string encoding)
        {
            bool mayBe = true;
            int i = 0;
            switch (encoding)
            {
                case "utf8":
                    while (mayBe && i < bytes.Length)
                        if (bytes[i] <= 0x7F)
                            i++;
                        else if (bytes[i] >= 0xC2 && bytes[i] <= 0xDF)
                        {
                            if (i < bytes.Length - 1 && bytes[i + 1] >= 0x80 && bytes[i + 1] <= 0xBF)
                                i += 2;
                            else
                                mayBe = false;
                        }
                        else if (bytes[i] >= 0xE0 && bytes[i] <= 0xEF)
                        {
                            if (i < bytes.Length - 2 && bytes[i + 1] >= 0x80 && bytes[i + 1] <= 0xBF && bytes[i + 2] >= 0x80 && bytes[i + 2] <= 0xBF)
                            {
                                if ((bytes[i] == 0xE0 && bytes[i + 1] < 0xA0) || (bytes[i] == 0xED && bytes[i + 1] > 0x9F))
                                    mayBe = false;
                                else
                                    i += 3;
                            }
                            else
                                mayBe = false;
                        }
                        else if (bytes[i] >= 0xF0 && bytes[i] <= 0xF4)
                        {
                            if (i < bytes.Length - 3 && bytes[i + 1] >= 0x80 && bytes[i + 1] <= 0xBF && bytes[i + 2] >= 0x80 && bytes[i + 2] <= 0xBF && bytes[i + 3] >= 0x80 && bytes[i + 3] <= 0xBF)
                            {
                                if ((bytes[i] == 0xF0 && bytes[i + 1] < 0x90) || (bytes[i] == 0xF4 && bytes[i + 1] > 0x8F))
                                    mayBe = false;
                                else
                                    i += 4;
                            }
                            else
                                mayBe = false;
                        }
                        else
                            mayBe = false;
                    break;
                case "gb":
                    while (mayBe && i < bytes.Length)
                        if (bytes[i] == 0xFF)
                            mayBe = false;
                        else if (bytes[i] <= 0x80)
                            i++;
                        else if (i == bytes.Length - 1)
                            mayBe = false;
                        else
                        {
                            i++;
                            if (bytes[i] == 0x7F)
                                mayBe = false;
                            else if (bytes[i] >= 0x40 && bytes[i] <= 0xFE)
                                i++;
                            else if (bytes[i] >= 0x30 && bytes[i] <= 0x39)
                            {
                                if (i == bytes.Length - 1)
                                    mayBe = false;
                                else
                                {
                                    i++;
                                    if (bytes[i] >= 0x81 && bytes[i] <= 0xFE)
                                    {
                                        if (i == bytes.Length - 1)
                                            mayBe = false;
                                        else
                                        {
                                            i++;
                                            if (bytes[i] >= 0x30 && bytes[i] <= 0x39)
                                                i++;
                                            else
                                                mayBe = false;
                                        }
                                    }
                                    else
                                        mayBe = false;
                                }
                            }
                            else
                                mayBe = false;
                        }
                    break;
            }
            return mayBe;
        }

        private void richTextBox1_SelectionChanged(object sender, EventArgs e)
        {
            if (!ignoreSelectionChanged)
            {
                ignoreSelectionChanged = true;
                listBox1.ClearSelected();
                //listBox1.SelectedIndices.Clear();
                int x = richTextBox1.SelectionStart;
                int y = x + richTextBox1.SelectionLength;

                // Solve the \r\n problem, though dirty
                int xLine = richTextBox1.GetLineFromCharIndex(x);
                int yLine = richTextBox1.GetLineFromCharIndex(y);
                for (int i = x + xLine; i < y + yLine; i++)
                {
                    if (utf8ToolStripButton.Checked)
                    {
                        int j = byteIndexOfUtf8CharAt[i];
                        listBox1.SelectedIndices.Add(j);
                        j++;
                        while (j < fileBytes.Length && utf8CharIndexOfByteAt[j] == -i - 1)
                        {
                            listBox1.SelectedIndices.Add(j);
                            j++;
                        }
                    }
                    else if (gbToolStripButton.Checked)
                    {
                        int j = byteIndexOfGbCharAt[i];
                        listBox1.SelectedIndices.Add(j);
                        j++;
                        while (j < fileBytes.Length && gbCharIndexOfByteAt[j] == -i - 1)
                        {
                            listBox1.SelectedIndices.Add(j);
                            j++;
                        }
                    }
                }
                ignoreSelectionChanged = false;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!ignoreSelectionChanged)
            {
                ignoreSelectionChanged = true;
                //
                ignoreSelectionChanged = false;
            }
        }
    }
}
