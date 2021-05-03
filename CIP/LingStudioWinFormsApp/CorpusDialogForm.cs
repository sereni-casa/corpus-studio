using System;
using System.Windows.Forms;

namespace LingStudioWinFormsApp
{
    public partial class CorpusDialogForm : Form
    {
        public CorpusDialogForm()
        {
            InitializeComponent();
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    new CorpusForm(saveFileDialog.FileName).ShowDialog();
                }
                catch (Exception)
                {
                    MessageBox.Show("无法新建语料库", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    new CorpusForm(openFileDialog.FileName).ShowDialog();
                }
                catch (Exception)
                {
                    MessageBox.Show("无法打开语料库", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void exitButton_Click(object sender, EventArgs e) => Close();
    }
}
