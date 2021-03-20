
namespace LingStudioWinFormsApp
{
    partial class DecoderForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DecoderForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.folderPanelToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.consolePanelToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.chooseFolderToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.multiColumnToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.binToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.octToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.decToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.hexToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.toolStrip4 = new System.Windows.Forms.ToolStrip();
            this.wrapToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.utf8ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.gbToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.folderToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.fileToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            this.toolStrip4.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.folderPanelToolStripButton,
            this.consolePanelToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(1888, 50);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // folderPanelToolStripButton
            // 
            this.folderPanelToolStripButton.Checked = true;
            this.folderPanelToolStripButton.CheckOnClick = true;
            this.folderPanelToolStripButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.folderPanelToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.folderPanelToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("folderPanelToolStripButton.Image")));
            this.folderPanelToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.folderPanelToolStripButton.Name = "folderPanelToolStripButton";
            this.folderPanelToolStripButton.Size = new System.Drawing.Size(171, 43);
            this.folderPanelToolStripButton.Text = "显示文件夹";
            this.folderPanelToolStripButton.CheckedChanged += new System.EventHandler(this.folderPanelToolStripButton_CheckedChanged);
            // 
            // consolePanelToolStripButton
            // 
            this.consolePanelToolStripButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.consolePanelToolStripButton.Checked = true;
            this.consolePanelToolStripButton.CheckOnClick = true;
            this.consolePanelToolStripButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.consolePanelToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.consolePanelToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("consolePanelToolStripButton.Image")));
            this.consolePanelToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.consolePanelToolStripButton.Name = "consolePanelToolStripButton";
            this.consolePanelToolStripButton.Size = new System.Drawing.Size(141, 43);
            this.consolePanelToolStripButton.Text = "显示文本";
            this.consolePanelToolStripButton.CheckedChanged += new System.EventHandler(this.consolePanelToolStripButton_CheckedChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 50);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1888, 890);
            this.splitContainer1.SplitterDistance = 400;
            this.splitContainer1.TabIndex = 1;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 50);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(400, 840);
            this.treeView1.TabIndex = 0;
            this.treeView1.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView1_BeforeSelect);
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // toolStrip2
            // 
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chooseFolderToolStripButton});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip2.Size = new System.Drawing.Size(400, 50);
            this.toolStrip2.TabIndex = 1;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // chooseFolderToolStripButton
            // 
            this.chooseFolderToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.chooseFolderToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("chooseFolderToolStripButton.Image")));
            this.chooseFolderToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.chooseFolderToolStripButton.Name = "chooseFolderToolStripButton";
            this.chooseFolderToolStripButton.Size = new System.Drawing.Size(141, 43);
            this.chooseFolderToolStripButton.Text = "选择目录";
            this.chooseFolderToolStripButton.Click += new System.EventHandler(this.chooseFolderToolStripButton_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.listBox1);
            this.splitContainer2.Panel1.Controls.Add(this.toolStrip3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.richTextBox1);
            this.splitContainer2.Panel2.Controls.Add(this.toolStrip4);
            this.splitContainer2.Size = new System.Drawing.Size(1484, 890);
            this.splitContainer2.SplitterDistance = 728;
            this.splitContainer2.TabIndex = 0;
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.Enabled = false;
            this.listBox1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listBox1.ItemHeight = 36;
            this.listBox1.Location = new System.Drawing.Point(0, 50);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox1.Size = new System.Drawing.Size(728, 840);
            this.listBox1.TabIndex = 2;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // toolStrip3
            // 
            this.toolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip3.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.multiColumnToolStripButton,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.binToolStripButton,
            this.octToolStripButton,
            this.decToolStripButton,
            this.hexToolStripButton});
            this.toolStrip3.Location = new System.Drawing.Point(0, 0);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip3.Size = new System.Drawing.Size(728, 50);
            this.toolStrip3.TabIndex = 1;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // multiColumnToolStripButton
            // 
            this.multiColumnToolStripButton.CheckOnClick = true;
            this.multiColumnToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.multiColumnToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("multiColumnToolStripButton.Image")));
            this.multiColumnToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.multiColumnToolStripButton.Name = "multiColumnToolStripButton";
            this.multiColumnToolStripButton.Size = new System.Drawing.Size(141, 43);
            this.multiColumnToolStripButton.Text = "多列显示";
            this.multiColumnToolStripButton.CheckedChanged += new System.EventHandler(this.multiColumnToolStripButton_CheckedChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 50);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(107, 43);
            this.toolStripLabel1.Text = "进制：";
            // 
            // binToolStripButton
            // 
            this.binToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.binToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("binToolStripButton.Image")));
            this.binToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.binToolStripButton.Name = "binToolStripButton";
            this.binToolStripButton.Size = new System.Drawing.Size(58, 43);
            this.binToolStripButton.Text = "2";
            this.binToolStripButton.Click += new System.EventHandler(this.binToolStripButton_Click);
            // 
            // octToolStripButton
            // 
            this.octToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.octToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("octToolStripButton.Image")));
            this.octToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.octToolStripButton.Name = "octToolStripButton";
            this.octToolStripButton.Size = new System.Drawing.Size(58, 43);
            this.octToolStripButton.Text = "8";
            this.octToolStripButton.Click += new System.EventHandler(this.octToolStripButton_Click);
            // 
            // decToolStripButton
            // 
            this.decToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.decToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("decToolStripButton.Image")));
            this.decToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.decToolStripButton.Name = "decToolStripButton";
            this.decToolStripButton.Size = new System.Drawing.Size(58, 43);
            this.decToolStripButton.Text = "10";
            this.decToolStripButton.Click += new System.EventHandler(this.decToolStripButton_Click);
            // 
            // hexToolStripButton
            // 
            this.hexToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.hexToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("hexToolStripButton.Image")));
            this.hexToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.hexToolStripButton.Name = "hexToolStripButton";
            this.hexToolStripButton.Size = new System.Drawing.Size(58, 43);
            this.hexToolStripButton.Text = "16";
            this.hexToolStripButton.Click += new System.EventHandler(this.hexToolStripButton_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.DetectUrls = false;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.richTextBox1.Location = new System.Drawing.Point(0, 50);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(752, 840);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            this.richTextBox1.WordWrap = false;
            this.richTextBox1.SelectionChanged += new System.EventHandler(this.richTextBox1_SelectionChanged);
            // 
            // toolStrip4
            // 
            this.toolStrip4.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip4.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.toolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wrapToolStripButton,
            this.toolStripSeparator2,
            this.toolStripLabel2,
            this.utf8ToolStripButton,
            this.gbToolStripButton});
            this.toolStrip4.Location = new System.Drawing.Point(0, 0);
            this.toolStrip4.Name = "toolStrip4";
            this.toolStrip4.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip4.Size = new System.Drawing.Size(752, 50);
            this.toolStrip4.TabIndex = 1;
            this.toolStrip4.Text = "toolStrip4";
            // 
            // wrapToolStripButton
            // 
            this.wrapToolStripButton.CheckOnClick = true;
            this.wrapToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.wrapToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("wrapToolStripButton.Image")));
            this.wrapToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.wrapToolStripButton.Name = "wrapToolStripButton";
            this.wrapToolStripButton.Size = new System.Drawing.Size(141, 43);
            this.wrapToolStripButton.Text = "自动换行";
            this.wrapToolStripButton.CheckedChanged += new System.EventHandler(this.wrapToolStripButton_CheckedChanged);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 50);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(107, 43);
            this.toolStripLabel2.Text = "编码：";
            // 
            // utf8ToolStripButton
            // 
            this.utf8ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.utf8ToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("utf8ToolStripButton.Image")));
            this.utf8ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.utf8ToolStripButton.Name = "utf8ToolStripButton";
            this.utf8ToolStripButton.Size = new System.Drawing.Size(107, 43);
            this.utf8ToolStripButton.Text = "UTF-8";
            this.utf8ToolStripButton.Click += new System.EventHandler(this.utf8ToolStripButton_Click);
            // 
            // gbToolStripButton
            // 
            this.gbToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.gbToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("gbToolStripButton.Image")));
            this.gbToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.gbToolStripButton.Name = "gbToolStripButton";
            this.gbToolStripButton.Size = new System.Drawing.Size(62, 43);
            this.gbToolStripButton.Text = "GB";
            this.gbToolStripButton.Click += new System.EventHandler(this.gbToolStripButton_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.folderToolStripStatusLabel,
            this.toolStripStatusLabel2,
            this.fileToolStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 940);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.ShowItemToolTips = true;
            this.statusStrip1.Size = new System.Drawing.Size(1888, 52);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(167, 39);
            this.toolStripStatusLabel1.Text = "当前目录：";
            // 
            // folderToolStripStatusLabel
            // 
            this.folderToolStripStatusLabel.AutoToolTip = true;
            this.folderToolStripStatusLabel.Name = "folderToolStripStatusLabel";
            this.folderToolStripStatusLabel.Size = new System.Drawing.Size(769, 39);
            this.folderToolStripStatusLabel.Spring = true;
            this.folderToolStripStatusLabel.Text = "无";
            this.folderToolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(167, 39);
            this.toolStripStatusLabel2.Text = "当前文件：";
            // 
            // fileToolStripStatusLabel
            // 
            this.fileToolStripStatusLabel.AutoToolTip = true;
            this.fileToolStripStatusLabel.Name = "fileToolStripStatusLabel";
            this.fileToolStripStatusLabel.Size = new System.Drawing.Size(769, 39);
            this.fileToolStripStatusLabel.Spring = true;
            this.fileToolStripStatusLabel.Text = "无";
            this.fileToolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(18F, 39F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1888, 992);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "编码查看器";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.toolStrip4.ResumeLayout(false);
            this.toolStrip4.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton folderPanelToolStripButton;
        private System.Windows.Forms.ToolStripButton consolePanelToolStripButton;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton chooseFolderToolStripButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel folderToolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel fileToolStripStatusLabel;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStrip toolStrip4;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ToolStripButton binToolStripButton;
        private System.Windows.Forms.ToolStripButton octToolStripButton;
        private System.Windows.Forms.ToolStripButton decToolStripButton;
        private System.Windows.Forms.ToolStripButton hexToolStripButton;
        private System.Windows.Forms.ToolStripButton multiColumnToolStripButton;
        private System.Windows.Forms.ToolStripButton utf8ToolStripButton;
        private System.Windows.Forms.ToolStripButton gbToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton wrapToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}

