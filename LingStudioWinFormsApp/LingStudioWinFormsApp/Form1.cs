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
            utf8ToolStripButton.Enabled = EncodingMayBe(fileBytes, "utf8");
            gbToolStripButton.Enabled = EncodingMayBe(fileBytes, "gb");
            if (utf8ToolStripButton.Enabled)
                ChooseEncoding("utf8");
            else if (gbToolStripButton.Enabled)
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
    }
}
