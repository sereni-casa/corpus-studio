using CIPLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace CorpusStudio
{
    /// <summary>
    /// CorpusWindow.xaml 的交互逻辑
    /// </summary>
    public partial class CorpusWindow : Window
    {
        private readonly string CorpusPath;
        private readonly Corpus Corpus;
        private bool HasCorpusChanged;
        public CorpusWindow(string corpusPath, Corpus corpus, bool hasCorpusChanged)
        {
            InitializeComponent();
            CorpusPath = corpusPath;
            Corpus = corpus;
            HasCorpusChanged = hasCorpusChanged;
            textFileListView.ItemsSource = Corpus.TextFiles;
        }

        private void AddFile(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dialog = new()
            {
                DefaultExt = ".txt",
                Filter = "文本文件|*.txt",
                Multiselect = true
            };
            if (dialog.ShowDialog() == true)
            {
                foreach (string path in dialog.FileNames)
                {
                    if (Corpus.TextFiles.AsParallel().Any(textFile => textFile.Path == path))
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
                        Corpus.TextFiles.Add(new TextFile()
                        {
                            Path = path,
                            Md5 = new MD5CryptoServiceProvider().ComputeHash(file),
                            Encoding = file.MayBeUtf8Encoded() ? "UTF-8" : (file.MayBeGbEncoded() ? "GB" : "?")
                        });
                        HasCorpusChanged = true;
                    }
                }
            }
        }

        private void RemoveFile(object sender, RoutedEventArgs e)
        {
            new List<TextFile>(textFileListView.SelectedItems.OfType<TextFile>()).ForEach(item => Corpus.TextFiles.Remove(item));
            HasCorpusChanged = true;
        }

        private void RemoveFiles(object sender, RoutedEventArgs e)
        {
            Corpus.TextFiles.Clear();
            HasCorpusChanged = true;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (HasCorpusChanged)
            {
                switch (MessageBox.Show("是否保存语料库？", "关闭语料库", MessageBoxButton.YesNoCancel))
                {
                    case MessageBoxResult.Cancel:
                        e.Cancel = true;
                        break;
                    case MessageBoxResult.Yes:
                        try
                        {
                            File.WriteAllBytes(CorpusPath, Corpus.ToJsonBytes());
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("无法保存语料库");
                            e.Cancel = true;
                        }
                        break;
                }
            }
        }

        private void SearchChar(object sender, RoutedEventArgs e)
        {
            if (charTextBox.Text == "")
            {
                searchListView.ItemsSource = null;
                return;
            }
            string searchString = charTextBox.Text;
            int leftRange = int.Parse(leftRangeTextBox.Text);
            int rightRange = int.Parse(rightRangeTextBox.Text);
            List<SearchResult> searchResults = new();
            Corpus.TextFiles.AsParallel().ForAll(textFile =>
            {
                string text = textFile.GetText();
                if (text == null)
                {
                    MessageBox.Show("读取文件失败：" + textFile.Path);
                }
                else
                {
                    for (int i = 0; i < text.Length; i++)
                    {
                        if (searchString.Contains(text[i]))
                        {
                            searchResults.Add(new SearchResult()
                            {
                                Left = text[Math.Max(i - leftRange, 0)..i],
                                Mid = text[i..(i + 1)],
                                Right = text[(i + 1)..Math.Min(i + 1 + rightRange, text.Length)],
                                Path = textFile.Path
                            });
                        }
                    }
                }
            });
            searchListView.ItemsSource = searchResults;
        }

        private void SearchRune(object sender, RoutedEventArgs e)
        {
            if (runeTextBox.Text == "")
            {
                searchListView.ItemsSource = null;
                return;
            }
            string searchString = runeTextBox.Text;
            List<Rune> searchRunes = searchString.EnumerateRunes().ToList();
            int leftRange = int.Parse(leftRangeTextBox.Text);
            int rightRange = int.Parse(rightRangeTextBox.Text);
            List<SearchResult> searchResults = new();
            Corpus.TextFiles.AsParallel().ForAll(textFile =>
            {
                string text = textFile.GetText();
                if (text == "")
                {
                    MessageBox.Show("读取文件失败：" + textFile.Path);
                }
                else
                {
                    List<Rune> runes = text.EnumerateRunes().ToList();
                    for (int i = 0; i < runes.Count; i++)
                    {
                        if (searchRunes.Contains(runes[i]))
                        {
                            StringBuilder left = new();
                            for (int j = Math.Max(i - leftRange, 0); j < i; j++)
                            {
                                left.Append(runes[j].ToString());
                            }
                            StringBuilder right = new();
                            for (int j = i + 1; j < Math.Min(i + 1 + rightRange, runes.Count); j++)
                            {
                                right.Append(runes[j].ToString());
                            }
                            searchResults.Add(new SearchResult()
                            {
                                Left = left.ToString(),
                                Mid = runes[i].ToString(),
                                Right = right.ToString(),
                                Path = textFile.Path
                            });
                        }
                    }
                }
            });
            searchListView.ItemsSource = searchResults;
        }

        private void RangeTextBoxValidate(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse((sender as TextBox).Text, out int value))
            {
                value = 20;
            }
            (sender as TextBox).Text = value.ToString();
        }

        private void SearchString(object sender, RoutedEventArgs e)
        {
            if (stringTextBox.Text == "")
            {
                searchListView.ItemsSource = null;
                return;
            }
            string searchString = stringTextBox.Text;
            int leftRange = int.Parse(leftRangeTextBox.Text);
            int rightRange = int.Parse(rightRangeTextBox.Text);
            List<SearchResult> searchResults = new();
            Corpus.TextFiles.AsParallel().ForAll(textFile =>
            {
                string text = textFile.GetText();
                if (text == "")
                {
                    MessageBox.Show("读取文件失败：" + textFile.Path);
                }
                else
                {
                    int start = 0;
                    int i;
                    while ((i = text.IndexOf(searchString, start, StringComparison.Ordinal)) != -1)
                    {
                        searchResults.Add(new SearchResult()
                        {
                            Left = text[Math.Max(i - leftRange, 0)..i],
                            Mid = searchString,
                            Right = text[(i + searchString.Length)..Math.Min(i + searchString.Length + rightRange, text.Length)],
                            Path = textFile.Path
                        });
                        start = i + 1;
                    }
                }
            });
            searchListView.ItemsSource = searchResults;
        }

        private void SelectedFilesChanged(object sender, SelectionChangedEventArgs e)
        {
            if (textFileListView.SelectedItems.Count == 0)
            {
                removeTextFileButton.IsEnabled = false;
                utf8EncodeButton.IsChecked = false;
                gbEncodeButton.IsChecked = false;
                utf8EncodeButton.IsEnabled = false;
                gbEncodeButton.IsEnabled = false;
                return;
            }
            removeTextFileButton.IsEnabled = true;
            var selectedTextFilesP = textFileListView.SelectedItems.OfType<TextFile>().AsParallel();
            utf8EncodeButton.IsChecked = selectedTextFilesP.All(textFile => textFile.Encoding == "UTF-8");
            gbEncodeButton.IsChecked = selectedTextFilesP.All(textFile => textFile.Encoding == "GB");
            utf8EncodeButton.IsEnabled = selectedTextFilesP.All(textFile => textFile.MayBeUtf8Encoded());
            gbEncodeButton.IsEnabled = selectedTextFilesP.All(textFile => textFile.MayBeGbEncoded());
        }

        private void Utf8Encode(object sender, RoutedEventArgs e)
        {
            textFileListView.SelectedItems.OfType<TextFile>()
                                 .AsParallel()
                                 .Where(textfile => textfile.MayBeUtf8Encoded())
                                 .ForAll(textfile => textfile.Encoding = "UTF-8");
        }

        private void GbEncode(object sender, RoutedEventArgs e)
        {
            textFileListView.SelectedItems.OfType<TextFile>()
                                 .AsParallel()
                                 .Where(textfile => textfile.MayBeGbEncoded())
                                 .ForAll(textfile => textfile.Encoding = "GB");

        }
    }
}
