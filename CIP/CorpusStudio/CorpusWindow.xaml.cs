using CIPLib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

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
            searchListView.ItemsSource = null;
            if (charTextBox.Text == "") return;
            string searchString = charTextBox.Text;
            int leftRange = int.Parse(leftRangeTextBox.Text), rightRange = int.Parse(rightRangeTextBox.Text);
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
            searchListView.ItemsSource = null;
            if (runeTextBox.Text == "") return;
            string searchString = runeTextBox.Text;
            List<Rune> searchRunes = searchString.EnumerateRunes().ToList();
            int leftRange = int.Parse(leftRangeTextBox.Text), rightRange = int.Parse(rightRangeTextBox.Text);
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

        private void RangeValidate(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse((sender as TextBox).Text, out int value))
            {
                value = 20;
            }
            (sender as TextBox).Text = value.ToString();
        }

        private void SearchString(object sender, RoutedEventArgs e)
        {
            searchListView.ItemsSource = null;
            if (stringTextBox.Text == "") return;
            string searchString = stringTextBox.Text;
            int leftRange = int.Parse(leftRangeTextBox.Text), rightRange = int.Parse(rightRangeTextBox.Text);
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
                    int start = 0, i;
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
            utf8EncodeButton.IsChecked = true;
        }

        private void GbEncode(object sender, RoutedEventArgs e)
        {
            textFileListView.SelectedItems.OfType<TextFile>()
                                 .AsParallel()
                                 .Where(textfile => textfile.MayBeGbEncoded())
                                 .ForAll(textfile => textfile.Encoding = "GB");
            gbEncodeButton.IsChecked = true;
        }

        private void CalcFreq(object sender, RoutedEventArgs e)
        {
            NgramOptions ngramOptions = (sender as Button).DataContext as NgramOptions;
            int minLength = int.Parse(ngramOptions.MinLength), maxLength = int.Parse(ngramOptions.MaxLength), minFreq = int.Parse(ngramOptions.MinFreq);
            bool hanOnly = ngramOptions.HanOnly;

            Debug.WriteLine(DateTime.Now.ToString());

            Dictionary<string, int> ngramDict = new(StringComparer.Ordinal);
            foreach (TextFile textFile in Corpus.TextFiles)
            {
                string text = textFile.GetText();
                if (text == null)
                {
                    MessageBox.Show("读取文件失败：" + textFile.Path);
                    continue;
                }
                for (int i = 0; i < text.Length; i++)
                {
                    if (hanOnly)
                    {
                        bool ok = true;
                        for (int n = 1; n <= Math.Min(minLength - 1, text.Length - i); n++)
                        {
                            if (!text[i + n - 1].IsHan())
                            {
                                ok = false;
                                break;
                            }
                        }
                        if (!ok) continue;
                    }
                    for (int n = minLength; n <= Math.Min(maxLength, text.Length - i) && (!hanOnly || text[i + n - 1].IsHan()); n++)
                    {
                        ngramDict[text.Substring(i, n)] = ngramDict.GetValueOrDefault(text.Substring(i, n), 0) + 1;
                    }
                }
            }

            Debug.WriteLine(DateTime.Now.ToString());

            /*Corpus.TextFiles.AsParallel().ForAll(textFile =>
            {
                string text = textFile.GetText();
                if (text == null)
                {
                    MessageBox.Show("读取文件失败：" + textFile.Path);
                }
                else
                {
                    int[] pointers = new int[text.Length];
                    for (int i = 0; i < text.Length; i++) pointers[i] = i;
                    Array.Sort(pointers, (x, y) =>
                    {
                        int i = 0;
                        while (true)
                        {
                            if (x + i == text.Length) return -1;
                            if (y + i == text.Length) return 1;
                            if (text[x + i] < text[y + i]) return -1;
                            if (text[x + i] > text[y + i]) return 1;
                            i++;
                        }
                    }
                    );
                    int[] coCharNums = new int[text.Length];
                    coCharNums[0] = 0;
                    for (int i = 1; i < text.Length; i++)
                    {
                        coCharNums[i] = 0;
                        while (pointers[i - 1] + coCharNums[i] < text.Length && pointers[i] + coCharNums[i] < text.Length && text[pointers[i - 1] + coCharNums[i]] == text[pointers[i] + coCharNums[i]]) coCharNums[i]++;
                    }
                    // TODO: Generate ngram table
                }
            });*/
            freqListView.ItemsSource = ngramDict.Where(kvp => kvp.Value >= minFreq);
        }

        private void SortListView(object sender, RoutedEventArgs e)
        {
            IEnumerable itemsSource = (sender as ListView).ItemsSource;
            if (itemsSource == null) return;
            ICollectionView view = CollectionViewSource.GetDefaultView(itemsSource);
            if (e.OriginalSource is not GridViewColumnHeader header || header.Role == GridViewColumnHeaderRole.Padding) return;
            string propertyName = (header.Column.DisplayMemberBinding as Binding).Path.Path;
            SortDescription descending = new(propertyName, ListSortDirection.Descending), ascending = new(propertyName, ListSortDirection.Ascending);
            bool isAscending = view.SortDescriptions.Contains(ascending);
            view.SortDescriptions.Clear();
            view.SortDescriptions.Add(isAscending ? descending : ascending);
            view.Refresh();
        }

        private void SearchRegex(object sender, RoutedEventArgs e)
        {
            searchListView.ItemsSource = null;
            if (regexTextBox.Text == "") return;
            string searchRegex = regexTextBox.Text;
            int leftRange = int.Parse(leftRangeTextBox.Text), rightRange = int.Parse(rightRangeTextBox.Text);
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
                    try
                    {
                        foreach (Match match in Regex.Matches(text, searchRegex))
                        {
                            searchResults.Add(new SearchResult()
                            {
                                Left = text[Math.Max(match.Index - leftRange, 0)..match.Index],
                                Mid = match.Value,
                                Right = text[(match.Index + match.Value.Length)..Math.Min(match.Index + match.Value.Length + rightRange, text.Length)],
                                Path = textFile.Path
                            });
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("正则表达式错误");
                        return;
                    }
                }
            });
            searchListView.ItemsSource = searchResults;
        }
    }
}
