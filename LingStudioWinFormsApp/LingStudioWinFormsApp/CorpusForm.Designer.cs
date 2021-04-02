
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.textFileListBox = new System.Windows.Forms.ListBox();
            this.textFIleToolStrip = new System.Windows.Forms.ToolStrip();
            this.addTextFileToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.removeTextFileToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.basicSearchTabPage = new System.Windows.Forms.TabPage();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.tabControl.SuspendLayout();
            this.fileTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.textFIleToolStrip.SuspendLayout();
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
            this.fileTabPage.Controls.Add(this.splitContainer1);
            this.fileTabPage.Location = new System.Drawing.Point(10, 56);
            this.fileTabPage.Name = "fileTabPage";
            this.fileTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.fileTabPage.Size = new System.Drawing.Size(1868, 904);
            this.fileTabPage.TabIndex = 0;
            this.fileTabPage.Text = "文件管理";
            this.fileTabPage.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.textFileListBox);
            this.splitContainer1.Panel1.Controls.Add(this.textFIleToolStrip);
            this.splitContainer1.Size = new System.Drawing.Size(1862, 898);
            this.splitContainer1.SplitterDistance = 620;
            this.splitContainer1.TabIndex = 0;
            // 
            // textFileListBox
            // 
            this.textFileListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textFileListBox.FormattingEnabled = true;
            this.textFileListBox.ItemHeight = 39;
            this.textFileListBox.Location = new System.Drawing.Point(0, 50);
            this.textFileListBox.Name = "textFileListBox";
            this.textFileListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.textFileListBox.Size = new System.Drawing.Size(620, 848);
            this.textFileListBox.TabIndex = 1;
            // 
            // textFIleToolStrip
            // 
            this.textFIleToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.textFIleToolStrip.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.textFIleToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addTextFileToolStripButton,
            this.removeTextFileToolStripButton});
            this.textFIleToolStrip.Location = new System.Drawing.Point(0, 0);
            this.textFIleToolStrip.Name = "textFIleToolStrip";
            this.textFIleToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.textFIleToolStrip.Size = new System.Drawing.Size(620, 50);
            this.textFIleToolStrip.TabIndex = 2;
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
            this.removeTextFileToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("removeTextFileToolStripButton.Image")));
            this.removeTextFileToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.removeTextFileToolStripButton.Name = "removeTextFileToolStripButton";
            this.removeTextFileToolStripButton.Size = new System.Drawing.Size(201, 43);
            this.removeTextFileToolStripButton.Text = "移除语料文件";
            this.removeTextFileToolStripButton.Click += new System.EventHandler(this.removeTextFileToolStripButton_Click);
            // 
            // basicSearchTabPage
            // 
            this.basicSearchTabPage.Location = new System.Drawing.Point(10, 56);
            this.basicSearchTabPage.Name = "basicSearchTabPage";
            this.basicSearchTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.basicSearchTabPage.Size = new System.Drawing.Size(1868, 904);
            this.basicSearchTabPage.TabIndex = 1;
            this.basicSearchTabPage.Text = "基本检索";
            this.basicSearchTabPage.UseVisualStyleBackColor = true;
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "文本文件|*.txt";
            this.openFileDialog.Multiselect = true;
            this.openFileDialog.Title = "打开文件";
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
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.textFIleToolStrip.ResumeLayout(false);
            this.textFIleToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage fileTabPage;
        private System.Windows.Forms.TabPage basicSearchTabPage;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox textFileListBox;
        private System.Windows.Forms.ToolStrip textFIleToolStrip;
        private System.Windows.Forms.ToolStripButton addTextFileToolStripButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStripButton removeTextFileToolStripButton;
    }
}