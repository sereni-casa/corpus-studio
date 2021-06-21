using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Win32;

namespace CorpusStudio
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static RoutedCommand AddTextFileCmd = new();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenCmdExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog dialog = new() { DefaultExt = ".corpus", Filter = "语料库文件|*.corpus" };
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
                if (corpus != null)
                {
                    CorpusInfo corpusInfo = new() { FilePath = dialog.FileName, Corpus = corpus };
                    (DataContext as MainWindowResources).CorpusCollection.Add(corpusInfo);
                    (DataContext as MainWindowResources).SelectedCorpus = corpusInfo;
                }
            }
        }

        private void OpenCmdCanExecute(object sender, CanExecuteRoutedEventArgs e) => e.CanExecute = true;

        private void SaveCmdExecuted(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void SaveCmdCanExecute(object sender, CanExecuteRoutedEventArgs e) => e.CanExecute = (DataContext as MainWindowResources).SelectedCorpus?.Unsaved ?? false;

        private void AddTextFileCmdExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog dialog = new()
            {
                DefaultExt = ".txt",
                Filter = "文本文件|*.txt",
                Multiselect = true
            };
            if (dialog.ShowDialog() == true)
            {
                foreach (string path in dialog.FileNames)
                {
                    if ((DataContext as MainWindowResources).SelectedCorpus.Corpus.TextFiles.AsParallel().Any(textFile => textFile.Path == path))
                    {
                        MessageBox.Show("文件已在语料库中：" + path);
                    }
                    else
                    {
                        byte[] file;
                        try
                        {
                            file = File.ReadAllBytes(path);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("文件无法打开：" + path);
                            continue;
                        }
                        (DataContext as MainWindowResources).SelectedCorpus.Corpus.TextFiles.Add(new TextFile()
                        {
                            Path = path,
                            Md5 = new MD5CryptoServiceProvider().ComputeHash(file),
                            Encoding = file.MayBeUtf8Encoded() ? "UTF-8" : (file.MayBeGbEncoded() ? "GB" : "?")
                        });
                        (DataContext as MainWindowResources).SelectedCorpus.Unsaved = true;
                    }
                }
            }
        }

        private void AddTextFileCmdCanExecute(object sender, CanExecuteRoutedEventArgs e) => e.CanExecute = (DataContext as MainWindowResources).SelectedCorpus != null;

        private void TextFileListViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (TextFile item in e.RemovedItems)
            {
                (DataContext as MainWindowResources).SelectedCorpus.SelectedTextFiles.Remove(item);
            }
            foreach (TextFile item in e.AddedItems)
            {
                (DataContext as MainWindowResources).SelectedCorpus.SelectedTextFiles.Add(item);
            }
        }
    }
}
