
namespace LingStudioWinFormsApp
{
    partial class CorpusForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CorpusForm));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.fileTabPage = new System.Windows.Forms.TabPage();
            this.textFileListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.textFileToolStrip = new System.Windows.Forms.ToolStrip();
            this.addTextFileToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.removeTextFileToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.md5ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.basicSearchTabPage = new System.Windows.Forms.TabPage();
            this.searchListView = new System.Windows.Forms.ListView();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.searchToolStrip = new System.Windows.Forms.ToolStrip();
            this.searchToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.searchToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.searchToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.tabControl.SuspendLayout();
            this.fileTabPage.SuspendLayout();
            this.textFileToolStrip.SuspendLayout();
            this.basicSearchTabPage.SuspendLayout();
            this.searchToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.statusStrip.Location = new System.Drawing.Point(0, 970);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1888, 22);
            this.statusStrip.TabIndex = 0;
            this.statusStrip.Text = "statusStrip1";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.fileTabPage);
            this.tabControl.Controls.Add(this.basicSearchTabPage);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1888, 970);
            this.tabControl.TabIndex = 1;
            // 
            // fileTabPage
            // 
            this.fileTabPage.Controls.Add(this.textFileListView);
            this.fileTabPage.Controls.Add(this.textFileToolStrip);
            this.fileTabPage.Location = new System.Drawing.Point(10, 56);
            this.fileTabPage.Name = "fileTabPage";
            this.fileTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.fileTabPage.Size = new System.Drawing.Size(1868, 904);
            this.fileTabPage.TabIndex = 0;
            this.fileTabPage.Text = "文件管理";
            this.fileTabPage.UseVisualStyleBackColor = true;
            // 
            // textFileListView
            // 
            this.textFileListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.textFileListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textFileListView.HideSelection = false;
            this.textFileListView.Location = new System.Drawing.Point(3, 3);
            this.textFileListView.Name = "textFileListView";
            this.textFileListView.Size = new System.Drawing.Size(1862, 848);
            this.textFileListView.TabIndex = 3;
            this.textFileListView.UseCompatibleStateImageBehavior = false;
            this.textFileListView.View = System.Windows.Forms.View.Details;
            this.textFileListView.SelectedIndexChanged += new System.EventHandler(this.textFileListView_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "路径";
            this.columnHeader1.Width = 600;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "MD5 校验码";
            this.columnHeader2.Width = 600;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "编码";
            this.columnHeader3.Width = 240;
            // 
            // textFileToolStrip
            // 
            this.textFileToolStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textFileToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.textFileToolStrip.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.textFileToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addTextFileToolStripButton,
            this.removeTextFileToolStripButton,
            this.md5ToolStripButton});
            this.textFileToolStrip.Location = new System.Drawing.Point(3, 851);
            this.textFileToolStrip.Name = "textFileToolStrip";
            this.textFileToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.textFileToolStrip.Size = new System.Drawing.Size(1862, 50);
            this.textFileToolStrip.TabIndex = 2;
            // 
            // addTextFileToolStripButton
            // 
            this.addTextFileToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.addTextFileToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("addTextFileToolStripButton.Image")));
            this.addTextFileToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addTextFileToolStripButton.Name = "addTextFileToolStripButton";
            this.addTextFileToolStripButton.Size = new System.Drawing.Size(201, 43);
            this.addTextFileToolStripButton.Text = "添加语料文件";
            this.addTextFileToolStripButton.Click += new System.EventHandler(this.addTextFileToolStripButton_Click);
            // 
            // removeTextFileToolStripButton
            // 
            this.removeTextFileToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.removeTextFileToolStripButton.Enabled = false;
            this.removeTextFileToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("removeTextFileToolStripButton.Image")));
            this.removeTextFileToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.removeTextFileToolStripButton.Name = "removeTextFileToolStripButton";
            this.removeTextFileToolStripButton.Size = new System.Drawing.Size(201, 43);
            this.removeTextFileToolStripButton.Text = "移除语料文件";
            this.removeTextFileToolStripButton.Click += new System.EventHandler(this.removeTextFileToolStripButton_Click);
            // 
            // md5ToolStripButton
            // 
            this.md5ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.md5ToolStripButton.Enabled = false;
            this.md5ToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("md5ToolStripButton.Image")));
            this.md5ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.md5ToolStripButton.Name = "md5ToolStripButton";
            this.md5ToolStripButton.Size = new System.Drawing.Size(160, 43);
            this.md5ToolStripButton.Text = "MD5 校验";
            this.md5ToolStripButton.Click += new System.EventHandler(this.md5ToolStripButton_Click);
            // 
            // basicSearchTabPage
            // 
            this.basicSearchTabPage.Controls.Add(this.searchListView);
            this.basicSearchTabPage.Controls.Add(this.searchToolStrip);
            this.basicSearchTabPage.Location = new System.Drawing.Point(10, 56);
            this.basicSearchTabPage.Name = "basicSearchTabPage";
            this.basicSearchTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.basicSearchTabPage.Size = new System.Drawing.Size(1868, 904);
            this.basicSearchTabPage.TabIndex = 1;
            this.basicSearchTabPage.Text = "基本检索";
            this.basicSearchTabPage.UseVisualStyleBackColor = true;
            // 
            // searchListView
            // 
            this.searchListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.searchListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchListView.HideSelection = false;
            this.searchListView.Location = new System.Drawing.Point(3, 53);
            this.searchListView.Name = "searchListView";
            this.searchListView.Size = new System.Drawing.Size(1862, 848);
            this.searchListView.TabIndex = 3;
            this.searchListView.UseCompatibleStateImageBehavior = false;
            this.searchListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "前文";
            this.columnHeader4.Width = 600;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "检索内容";
            this.columnHeader5.Width = 240;
            // 
            // searchToolStrip
            // 
            this.searchToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.searchToolStrip.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.searchToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.searchToolStripLabel,
            this.searchToolStripTextBox,
            this.searchToolStripButton});
            this.searchToolStrip.Location = new System.Drawing.Point(3, 3);
            this.searchToolStrip.Name = "searchToolStrip";
            this.searchToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.searchToolStrip.Size = new System.Drawing.Size(1862, 50);
            this.searchToolStrip.TabIndex = 4;
            this.searchToolStrip.Text = "toolStrip1";
            // 
            // searchToolStripLabel
            // 
            this.searchToolStripLabel.Name = "searchToolStripLabel";
            this.searchToolStripLabel.Size = new System.Drawing.Size(167, 43);
            this.searchToolStripLabel.Text = "检索内容：";
            // 
            // searchToolStripTextBox
            // 
            this.searchToolStripTextBox.Name = "searchToolStripTextBox";
            this.searchToolStripTextBox.Size = new System.Drawing.Size(200, 50);
            this.searchToolStripTextBox.TextChanged += new System.EventHandler(this.searchToolStripTextBox_TextChanged);
            // 
            // searchToolStripButton
            // 
            this.searchToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.searchToolStripButton.Enabled = false;
            this.searchToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("searchToolStripButton.Image")));
            this.searchToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.searchToolStripButton.Name = "searchToolStripButton";
            this.searchToolStripButton.Size = new System.Drawing.Size(81, 43);
            this.searchToolStripButton.Text = "检索";
            this.searchToolStripButton.Click += new System.EventHandler(this.searchToolStripButton_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "文本文件|*.txt";
            this.openFileDialog.Multiselect = true;
            this.openFileDialog.Title = "打开文件";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "后文";
            this.columnHeader6.Width = 600;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "路径";
            this.columnHeader7.Width = 300;
            // 
            // CorpusForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(18F, 39F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1888, 992);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.statusStrip);
            this.Name = "CorpusForm";
            this.ShowIcon = false;
            this.Text = "语料库";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CorpusForm_FormClosing);
            this.tabControl.ResumeLayout(false);
            this.fileTabPage.ResumeLayout(false);
            this.fileTabPage.PerformLayout();
            this.textFileToolStrip.ResumeLayout(false);
            this.textFileToolStrip.PerformLayout();
            this.basicSearchTabPage.ResumeLayout(false);
            this.basicSearchTabPage.PerformLayout();
            this.searchToolStrip.ResumeLayout(false);
            this.searchToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage fileTabPage;
        private System.Windows.Forms.TabPage basicSearchTabPage;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ListView textFileListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ToolStrip textFileToolStrip;
        private System.Windows.Forms.ToolStripButton addTextFileToolStripButton;
        private System.Windows.Forms.ToolStripButton removeTextFileToolStripButton;
        private System.Windows.Forms.ToolStripButton md5ToolStripButton;
        private System.Windows.Forms.ListView searchListView;
        private System.Windows.Forms.ToolStrip searchToolStrip;
        private System.Windows.Forms.ToolStripLabel searchToolStripLabel;
        private System.Windows.Forms.ToolStripTextBox searchToolStripTextBox;
        private System.Windows.Forms.ToolStripButton searchToolStripButton;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
    }
}