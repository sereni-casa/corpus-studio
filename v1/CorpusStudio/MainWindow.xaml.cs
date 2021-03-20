using CIPLib;
using System;
using System.IO;
using System.Windows;

namespace CorpusStudio
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow() => InitializeComponent();

        private void Exit(object sender, RoutedEventArgs e) => Close();

        private void NewCorpus(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dialog = new() { DefaultExt = ".corpus", Filter = "语料库文件|*.corpus" };
            if (dialog.ShowDialog() == true)
            {
                new CorpusWindow(dialog.FileName, new Corpus(), true).ShowDialog();
            }
        }

        private void OpenCorpus(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dialog = new() { DefaultExt = ".corpus", Filter = "语料库文件|*.corpus" };
            if (dialog.ShowDialog() == true)
            {
                Corpus corpus = null;
                try
                {
                    corpus = Corpus.FromJsonBytes(File.ReadAllBytes(dialog.FileName));
                }
                catch (Exception)
                {
                    MessageBox.Show("无法打开语料库");
                }
                new CorpusWindow(dialog.FileName, corpus, false).ShowDialog();
            }
        }
    }
}
