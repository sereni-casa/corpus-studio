
namespace LingStudioWinFormsApp
{
    partial class NagaoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NagaoForm));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.corpusTabPage = new System.Windows.Forms.TabPage();
            this.corpusTextBox = new System.Windows.Forms.TextBox();
            this.corpusToolStrip = new System.Windows.Forms.ToolStrip();
            this.addCorpusFromFileToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.clearCorpusToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.listTabPage = new System.Windows.Forms.TabPage();
            this.listListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.listToolStrip = new System.Windows.Forms.ToolStrip();
            this.generateListToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.clearListToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.resultTabPage = new System.Windows.Forms.TabPage();
            this.hanOnlyCheckBox = new System.Windows.Forms.CheckBox();
            this.resultListView = new System.Windows.Forms.ListView();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.calcButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.minFreqNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.maxLengthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.minLengthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.taskToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.taskToolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.tabControl.SuspendLayout();
            this.corpusTabPage.SuspendLayout();
            this.corpusToolStrip.SuspendLayout();
            this.listTabPage.SuspendLayout();
            this.listToolStrip.SuspendLayout();
            this.resultTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minFreqNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxLengthNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minLengthNumericUpDown)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.corpusTabPage);
            this.tabControl.Controls.Add(this.listTabPage);
            this.tabControl.Controls.Add(this.resultTabPage);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1888, 940);
            this.tabControl.TabIndex = 0;
            // 
            // corpusTabPage
            // 
            this.corpusTabPage.Controls.Add(this.corpusTextBox);
            this.corpusTabPage.Controls.Add(this.corpusToolStrip);
            this.corpusTabPage.Location = new System.Drawing.Point(10, 56);
            this.corpusTabPage.Name = "corpusTabPage";
            this.corpusTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.corpusTabPage.Size = new System.Drawing.Size(1868, 874);
            this.corpusTabPage.TabIndex = 0;
            this.corpusTabPage.Text = "一　输入语料";
            this.corpusTabPage.UseVisualStyleBackColor = true;
            // 
            // corpusTextBox
            // 
            this.corpusTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.corpusTextBox.Location = new System.Drawing.Point(3, 53);
            this.corpusTextBox.Multiline = true;
            this.corpusTextBox.Name = "corpusTextBox";
            this.corpusTextBox.PlaceholderText = "在此输入语料";
            this.corpusTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.corpusTextBox.Size = new System.Drawing.Size(1862, 818);
            this.corpusTextBox.TabIndex = 0;
            this.corpusTextBox.TextChanged += new System.EventHandler(this.corpusTextBox_TextChanged);
            // 
            // corpusToolStrip
            // 
            this.corpusToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.corpusToolStrip.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.corpusToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addCorpusFromFileToolStripButton,
            this.clearCorpusToolStripButton});
            this.corpusToolStrip.Location = new System.Drawing.Point(3, 3);
            this.corpusToolStrip.Name = "corpusToolStrip";
            this.corpusToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.corpusToolStrip.Size = new System.Drawing.Size(1862, 50);
            this.corpusToolStrip.TabIndex = 1;
            this.corpusToolStrip.Text = "toolStrip1";
            // 
            // addCorpusFromFileToolStripButton
            // 
            this.addCorpusFromFileToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.addCorpusFromFileToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("addCorpusFromFileToolStripButton.Image")));
            this.addCorpusFromFileToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addCorpusFromFileToolStripButton.Name = "addCorpusFromFileToolStripButton";
            this.addCorpusFromFileToolStripButton.Size = new System.Drawing.Size(231, 43);
            this.addCorpusFromFileToolStripButton.Text = "从文件添加语料";
            this.addCorpusFromFileToolStripButton.Click += new System.EventHandler(this.addCorpusFromFileToolStripButton_Click);
            // 
            // clearCorpusToolStripButton
            // 
            this.clearCorpusToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.clearCorpusToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("clearCorpusToolStripButton.Image")));
            this.clearCorpusToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.clearCorpusToolStripButton.Name = "clearCorpusToolStripButton";
            this.clearCorpusToolStripButton.Size = new System.Drawing.Size(141, 43);
            this.clearCorpusToolStripButton.Text = "清除语料";
            this.clearCorpusToolStripButton.Click += new System.EventHandler(this.clearCorpusToolStripButton_Click);
            // 
            // listTabPage
            // 
            this.listTabPage.Controls.Add(this.listListView);
            this.listTabPage.Controls.Add(this.listToolStrip);
            this.listTabPage.Location = new System.Drawing.Point(10, 56);
            this.listTabPage.Name = "listTabPage";
            this.listTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.listTabPage.Size = new System.Drawing.Size(1868, 874);
            this.listTabPage.TabIndex = 1;
            this.listTabPage.Text = "二　生成列表";
            this.listTabPage.UseVisualStyleBackColor = true;
            // 
            // listListView
            // 
            this.listListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listListView.HideSelection = false;
            this.listListView.Location = new System.Drawing.Point(3, 53);
            this.listListView.Name = "listListView";
            this.listListView.Size = new System.Drawing.Size(1862, 818);
            this.listListView.TabIndex = 1;
            this.listListView.UseCompatibleStateImageBehavior = false;
            this.listListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "子串序号";
            this.columnHeader1.Width = 240;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "子串起点";
            this.columnHeader2.Width = 240;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "公共前缀长度";
            this.columnHeader3.Width = 240;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "子串";
            this.columnHeader4.Width = 960;
            // 
            // listToolStrip
            // 
            this.listToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.listToolStrip.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.listToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generateListToolStripButton,
            this.clearListToolStripButton});
            this.listToolStrip.Location = new System.Drawing.Point(3, 3);
            this.listToolStrip.Name = "listToolStrip";
            this.listToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.listToolStrip.Size = new System.Drawing.Size(1862, 50);
            this.listToolStrip.TabIndex = 0;
            this.listToolStrip.Text = "toolStrip1";
            // 
            // generateListToolStripButton
            // 
            this.generateListToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.generateListToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("generateListToolStripButton.Image")));
            this.generateListToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.generateListToolStripButton.Name = "generateListToolStripButton";
            this.generateListToolStripButton.Size = new System.Drawing.Size(141, 43);
            this.generateListToolStripButton.Text = "生成列表";
            this.generateListToolStripButton.Click += new System.EventHandler(this.generateListToolStripButton_Click);
            // 
            // clearListToolStripButton
            // 
            this.clearListToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.clearListToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("clearListToolStripButton.Image")));
            this.clearListToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.clearListToolStripButton.Name = "clearListToolStripButton";
            this.clearListToolStripButton.Size = new System.Drawing.Size(141, 43);
            this.clearListToolStripButton.Text = "清除列表";
            this.clearListToolStripButton.Click += new System.EventHandler(this.clearListToolStripButton_Click);
            // 
            // resultTabPage
            // 
            this.resultTabPage.Controls.Add(this.hanOnlyCheckBox);
            this.resultTabPage.Controls.Add(this.resultListView);
            this.resultTabPage.Controls.Add(this.calcButton);
            this.resultTabPage.Controls.Add(this.label3);
            this.resultTabPage.Controls.Add(this.label2);
            this.resultTabPage.Controls.Add(this.label1);
            this.resultTabPage.Controls.Add(this.minFreqNumericUpDown);
            this.resultTabPage.Controls.Add(this.maxLengthNumericUpDown);
            this.resultTabPage.Controls.Add(this.minLengthNumericUpDown);
            this.resultTabPage.Location = new System.Drawing.Point(10, 56);
            this.resultTabPage.Name = "resultTabPage";
            this.resultTabPage.Size = new System.Drawing.Size(1868, 874);
            this.resultTabPage.TabIndex = 2;
            this.resultTabPage.Text = "三　统计频次";
            this.resultTabPage.UseVisualStyleBackColor = true;
            // 
            // hanOnlyCheckBox
            // 
            this.hanOnlyCheckBox.AutoSize = true;
            this.hanOnlyCheckBox.Location = new System.Drawing.Point(3, 168);
            this.hanOnlyCheckBox.Name = "hanOnlyCheckBox";
            this.hanOnlyCheckBox.Size = new System.Drawing.Size(175, 43);
            this.hanOnlyCheckBox.TabIndex = 8;
            this.hanOnlyCheckBox.Text = "仅限汉字";
            this.hanOnlyCheckBox.UseVisualStyleBackColor = true;
            // 
            // resultListView
            // 
            this.resultListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.resultListView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.resultListView.HideSelection = false;
            this.resultListView.Location = new System.Drawing.Point(0, 223);
            this.resultListView.Name = "resultListView";
            this.resultListView.Size = new System.Drawing.Size(1868, 651);
            this.resultListView.TabIndex = 7;
            this.resultListView.UseCompatibleStateImageBehavior = false;
            this.resultListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "子串起点";
            this.columnHeader5.Width = 240;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "子串频次";
            this.columnHeader6.Width = 240;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "子串";
            this.columnHeader7.Width = 960;
            // 
            // calcButton
            // 
            this.calcButton.Location = new System.Drawing.Point(318, 159);
            this.calcButton.Name = "calcButton";
            this.calcButton.Size = new System.Drawing.Size(188, 58);
            this.calcButton.TabIndex = 6;
            this.calcButton.Text = "计算";
            this.calcButton.UseVisualStyleBackColor = true;
            this.calcButton.Click += new System.EventHandler(this.calcButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(197, 39);
            this.label3.TabIndex = 5;
            this.label3.Text = "子串最小频度";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(197, 39);
            this.label2.TabIndex = 4;
            this.label2.Text = "子串最大长度";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 39);
            this.label1.TabIndex = 3;
            this.label1.Text = "子串最小长度";
            // 
            // minFreqNumericUpDown
            // 
            this.minFreqNumericUpDown.Location = new System.Drawing.Point(206, 107);
            this.minFreqNumericUpDown.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.minFreqNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.minFreqNumericUpDown.Name = "minFreqNumericUpDown";
            this.minFreqNumericUpDown.Size = new System.Drawing.Size(300, 46);
            this.minFreqNumericUpDown.TabIndex = 2;
            this.minFreqNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // maxLengthNumericUpDown
            // 
            this.maxLengthNumericUpDown.Location = new System.Drawing.Point(206, 55);
            this.maxLengthNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maxLengthNumericUpDown.Name = "maxLengthNumericUpDown";
            this.maxLengthNumericUpDown.Size = new System.Drawing.Size(300, 46);
            this.maxLengthNumericUpDown.TabIndex = 1;
            this.maxLengthNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maxLengthNumericUpDown.ValueChanged += new System.EventHandler(this.maxLengthNumericUpDown_ValueChanged);
            // 
            // minLengthNumericUpDown
            // 
            this.minLengthNumericUpDown.Location = new System.Drawing.Point(206, 3);
            this.minLengthNumericUpDown.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.minLengthNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.minLengthNumericUpDown.Name = "minLengthNumericUpDown";
            this.minLengthNumericUpDown.Size = new System.Drawing.Size(300, 46);
            this.minLengthNumericUpDown.TabIndex = 0;
            this.minLengthNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.minLengthNumericUpDown.ValueChanged += new System.EventHandler(this.minLengthNumericUpDown_ValueChanged);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "文本文件|*.txt";
            this.openFileDialog.Multiselect = true;
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.taskToolStripStatusLabel,
            this.taskToolStripProgressBar});
            this.statusStrip.Location = new System.Drawing.Point(0, 940);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1888, 52);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip1";
            // 
            // taskToolStripStatusLabel
            // 
            this.taskToolStripStatusLabel.Name = "taskToolStripStatusLabel";
            this.taskToolStripStatusLabel.Size = new System.Drawing.Size(77, 39);
            this.taskToolStripStatusLabel.Text = "空闲";
            // 
            // taskToolStripProgressBar
            // 
            this.taskToolStripProgressBar.Name = "taskToolStripProgressBar";
            this.taskToolStripProgressBar.Size = new System.Drawing.Size(100, 36);
            this.taskToolStripProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.taskToolStripProgressBar.Visible = false;
            // 
            // NagaoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(18F, 39F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1888, 992);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.statusStrip);
            this.Name = "NagaoForm";
            this.ShowIcon = false;
            this.Text = "Nagao 算法演示";
            this.tabControl.ResumeLayout(false);
            this.corpusTabPage.ResumeLayout(false);
            this.corpusTabPage.PerformLayout();
            this.corpusToolStrip.ResumeLayout(false);
            this.corpusToolStrip.PerformLayout();
            this.listTabPage.ResumeLayout(false);
            this.listTabPage.PerformLayout();
            this.listToolStrip.ResumeLayout(false);
            this.listToolStrip.PerformLayout();
            this.resultTabPage.ResumeLayout(false);
            this.resultTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minFreqNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxLengthNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minLengthNumericUpDown)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage corpusTabPage;
        private System.Windows.Forms.TextBox corpusTextBox;
        private System.Windows.Forms.TabPage listTabPage;
        private System.Windows.Forms.TabPage resultTabPage;
        private System.Windows.Forms.ToolStrip corpusToolStrip;
        private System.Windows.Forms.ToolStripButton addCorpusFromFileToolStripButton;
        private System.Windows.Forms.ToolStripButton clearCorpusToolStripButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel taskToolStripStatusLabel;
        private System.Windows.Forms.ToolStripProgressBar taskToolStripProgressBar;
        private System.Windows.Forms.ListView listListView;
        private System.Windows.Forms.ToolStrip listToolStrip;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ToolStripButton generateListToolStripButton;
        private System.Windows.Forms.ToolStripButton clearListToolStripButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown minFreqNumericUpDown;
        private System.Windows.Forms.NumericUpDown maxLengthNumericUpDown;
        private System.Windows.Forms.NumericUpDown minLengthNumericUpDown;
        private System.Windows.Forms.ListView resultListView;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.Button calcButton;
        private System.Windows.Forms.CheckBox hanOnlyCheckBox;
    }
}