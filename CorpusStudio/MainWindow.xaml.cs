using Microsoft.Win32;
using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CorpusStudio
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static readonly RoutedCommand AddTextFileCmd = new();
        private readonly MainWindowResources data;

        public MainWindow()
        {
            InitializeComponent();
            data = DataContext as MainWindowResources;
        }

        private void OpenCmdExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog dialog = new() { DefaultExt = ".corpus", Filter = "语料库文件|*.corpus" };
            if (dialog.ShowDialog() != true) return;
            try
            {
                data.CorpusCollection.Add(new CorpusInfo() { FilePath = dialog.FileName, Corpus = Corpus.FromJsonBytes(File.ReadAllBytes(dialog.FileName)) });
                data.SelectedCorpus = data.CorpusCollection.Last();
            }
            catch (Exception)
            {
                if (MessageBox.Show($"无法打开语料库：{dialog.FileName}\r\n是否重试？", "打开失败", MessageBoxButton.YesNo) == MessageBoxResult.Yes) OpenCmdExecuted(sender, e);
            }
        }

        private void OpenCmdCanExecute(object sender, CanExecuteRoutedEventArgs e) => e.CanExecute = true;

        private void SaveCmdExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                File.WriteAllBytes(data.SelectedCorpus.FilePath, data.SelectedCorpus.Corpus.ToJsonBytes());
                data.SelectedCorpus.Unsaved = false;
            }
            catch (Exception)
            {
                if (MessageBox.Show($"无法保存语料库：{data.SelectedCorpus.FilePath}\r\n是否重试？", "保存失败", MessageBoxButton.YesNo) == MessageBoxResult.Yes) SaveCmdExecuted(sender, e);
            }
        }

        private void SaveCmdCanExecute(object sender, CanExecuteRoutedEventArgs e) => e.CanExecute = data.SelectedCorpus?.Unsaved ?? false;

        private void AddTextFileCmdExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog dialog = new() { DefaultExt = ".txt", Filter = "文本文件|*.txt", Multiselect = true };
            if (dialog.ShowDialog() != true) return;
            foreach (string path in dialog.FileNames)
            {
                if (data.SelectedCorpus.Corpus.TextFiles.AsParallel().Any(textFile => textFile.Path == path))
                {
                    MessageBox.Show($"文件已在语料库中：{path}");
                    continue;
                }
                try
                {
                    byte[] file = File.ReadAllBytes(path);
                    data.SelectedCorpus.Corpus.TextFiles.Add(new TextFile()
                    {
                        Path = path,
                        Md5 = new MD5CryptoServiceProvider().ComputeHash(file),
                        Encoding = file.MayBeUtf8Encoded() ? "UTF-8" : (file.MayBeGbEncoded() ? "GB" : "?")
                    });
                    data.SelectedCorpus.Unsaved = true;
                }
                catch (Exception)
                {
                    MessageBox.Show($"文件无法打开：{path}");
                    continue;
                }
            }
        }

        private void AddTextFileCmdCanExecute(object sender, CanExecuteRoutedEventArgs e) => e.CanExecute = data.SelectedCorpus != null;

        private void TextFileListViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (TextFile item in e.RemovedItems) data.SelectedCorpus.SelectedTextFiles.Remove(item);
            foreach (TextFile item in e.AddedItems) data.SelectedCorpus.SelectedTextFiles.Add(item);
        }
    }
}
