using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
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
        public static readonly RoutedCommand AboutCmd = new(), ExitCmd = new(), SaveAllCmd = new(), TextFileAddCmd = new(), TextFileRemoveCmd = new(), TextFileSelectAllCmd = new(), TextFileUnselectAllCmd = new(), TextFileChooseUtf8EncodingCmd = new(), TextFileChooseGbEncodingCmd = new(), CountCmd = new(), SearchCmd = new();
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
                data.CorpusCollection.Add(new CorpusInfo(false) { FilePath = dialog.FileName, Corpus = Corpus.FromJsonBytes(File.ReadAllBytes(dialog.FileName)) });
                data.SelectedCorpus = data.CorpusCollection.Last();
            }
            catch (Exception)
            {
                if (MessageBox.Show($"无法打开语料库：{dialog.FileName}\r\n是否重试？", "打开失败", MessageBoxButton.YesNo) == MessageBoxResult.Yes) OpenCmdExecuted(sender, e);
            }
        }

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

        private void TextFileAddCmdExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            string path = e.Parameter as string;
            if (path == "File")
            {
                OpenFileDialog dialog = new() { DefaultExt = ".txt", Filter = "文本文件|*.txt", Multiselect = true };
                if (dialog.ShowDialog() != true) return;
                foreach (string filePath in dialog.FileNames)
                {
                    TextFileAddCmd.Execute(filePath, sender as IInputElement);
                }
                return;
            }
            if (path is "Dir" or "DirTree")
            {
                CommonOpenFileDialog dialog = new() { IsFolderPicker = true, Multiselect = true };
                if (dialog.ShowDialog(this) != CommonFileDialogResult.Ok) return;
                Queue<string> folders = new(dialog.FileNames);
                while (folders.Count > 0)
                {
                    string folder = folders.Dequeue();
                    if (path == "DirTree")
                    {
                        foreach (string subfolder in Directory.EnumerateDirectories(folder))
                        {
                            folders.Enqueue(subfolder);
                        }
                    }
                    foreach (string filePath in Directory.EnumerateFiles(folder, "*.txt"))
                    {
                        TextFileAddCmd.Execute(filePath, sender as IInputElement);
                    }
                }
                return;
            }
            if (data.SelectedCorpus.Corpus.TextFiles.AsParallel().Any(textFile => textFile.Path == path))
            {
                MessageBox.Show($"文件已在语料库中：{path}");
                return;
            }
            try
            {
                byte[] file = File.ReadAllBytes(path);
                data.SelectedCorpus.Corpus.TextFiles.Add(new TextFile(path, file.MayBeUtf8Encoded() ? "UTF-8" : (file.MayBeGbEncoded() ? "GB" : "?")));
                data.SelectedCorpus.Unsaved = true;
            }
            catch (Exception)
            {
                MessageBox.Show($"文件无法打开：{path}");
            }
        }

        private void CanExecuteWhenHasSelectedCorpus(object sender, CanExecuteRoutedEventArgs e) => e.CanExecute = data.SelectedCorpus != null;

        private void CloseCmdExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (data.SelectedCorpus.Unsaved)
            {
                MessageBoxResult result = MessageBox.Show($"语料库未保存：{data.SelectedCorpus.FilePath}\r\n是否保存？", "关闭语料库", MessageBoxButton.YesNoCancel);
                if (result == MessageBoxResult.Cancel) return;
                if (result == MessageBoxResult.Yes)
                {
                    SaveCmdExecuted(sender, e);
                    if (data.SelectedCorpus.Unsaved) return;
                }
            }
            data.CorpusCollection.Remove(data.SelectedCorpus);
        }

        private void NewCmdExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog dialog = new() { DefaultExt = ".corpus", Filter = "语料库文件|*.corpus" };
            if (dialog.ShowDialog() != true) return;
            data.CorpusCollection.Add(new CorpusInfo(true) { FilePath = dialog.FileName, Corpus = new Corpus() });
            data.SelectedCorpus = data.CorpusCollection.Last();
        }

        private void TextFileRemoveCmdExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            List<TextFile> textFilesToRemove = new();
            foreach (TextFile item in (e.Parameter as ListView).SelectedItems)
            {
                textFilesToRemove.Add(item);
            }
            foreach (TextFile item in textFilesToRemove)
            {
                data.SelectedCorpus.Corpus.TextFiles.Remove(item);
            }
            data.SelectedCorpus.Unsaved = true;
        }

        private void TextFileRemoveCmdCanExecute(object sender, CanExecuteRoutedEventArgs e) => e.CanExecute = ((e.Parameter as ListView)?.SelectedItems.Count ?? 0) > 0;

        private void TextFileSelectAllCmdExecuted(object sender, ExecutedRoutedEventArgs e) => (e.Parameter as ListView).SelectAll();

        private void TextFileSelectAllCmdCanExecute(object sender, CanExecuteRoutedEventArgs e) => e.CanExecute = ((e.Parameter as ListView)?.SelectedItems.Count ?? 0) < ((e.Parameter as ListView)?.Items.Count ?? 0);

        private void ExitCmdExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            while (data.SelectedCorpus != null)
            {
                CorpusInfo corpusToClose = data.SelectedCorpus;
                CloseCmdExecuted(sender, e);
                if (data.SelectedCorpus == corpusToClose) return;
            }
            Application.Current.Shutdown();
        }

        private void AlwaysCanExecute(object sender, CanExecuteRoutedEventArgs e) => e.CanExecute = true;

        private void CountCmdExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            int minLen = int.Parse(data.SelectedCorpus.CountMinLen);
            int maxLen = int.Parse(data.SelectedCorpus.CountMaxLen);
            int minFreq = int.Parse(data.SelectedCorpus.CountMinFreq);
            bool hanOnly = data.SelectedCorpus.CountHanOnly;
            DateTime time0 = DateTime.Now;

            Dictionary<string, int> ngramDict = new(StringComparer.Ordinal);
            foreach (TextFile textFile in data.SelectedCorpus.Corpus.TextFiles)
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
                        for (int n = 1; n <= Math.Min(minLen - 1, text.Length - i); n++)
                        {
                            if (!text[i + n - 1].IsHan())
                            {
                                ok = false;
                                break;
                            }
                        }
                        if (!ok) continue;
                    }
                    for (int n = minLen; n <= Math.Min(maxLen, text.Length - i) && (!hanOnly || text[i + n - 1].IsHan()); n++)
                    {
                        ngramDict[text.Substring(i, n)] = ngramDict.GetValueOrDefault(text.Substring(i, n), 0) + 1;
                    }
                }
            }
            var results = ngramDict.Where(kvp => kvp.Value >= minFreq);
            DateTime time1 = DateTime.Now;
            MessageBox.Show("统计完成\r\n共计" + results.Count() + "项\r\n耗时" + (time1 - time0).TotalSeconds.ToString() + "秒\r\n即将输出至Excel");
            SaveFileDialog dialog = new() { DefaultExt = ".xlsx", Filter = "Excel 工作簿|*.xlsx" };
            if (dialog.ShowDialog() != true) return;
            SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Create(dialog.FileName, SpreadsheetDocumentType.Workbook);

            WorkbookPart workbookpart = spreadsheetDocument.AddWorkbookPart();
            workbookpart.Workbook = new Workbook();

            WorksheetPart worksheetPart = workbookpart.AddNewPart<WorksheetPart>();
            worksheetPart.Worksheet = new Worksheet(new SheetData());

            Sheets sheets = spreadsheetDocument.WorkbookPart.Workbook.AppendChild(new Sheets());

            Sheet sheet = new() { Id = spreadsheetDocument.WorkbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "串频统计" };
            sheets.Append(sheet);


            Excel.InsertText(spreadsheetDocument, "字符串", "A", 1, worksheetPart);
            Excel.InsertText(spreadsheetDocument, "频次", "B", 1, worksheetPart);

            for (int i = 0; i < results.Count(); i++)
            {
                Excel.InsertText(spreadsheetDocument, results.ElementAt(i).Key, "A", (uint)i + 2, worksheetPart);
                Excel.InsertText(spreadsheetDocument, results.ElementAt(i).Value.ToString(), "B", (uint)i + 2, worksheetPart);
            }

            workbookpart.Workbook.Save();
            spreadsheetDocument.Close();

            
        }

        private void CountCmdCanExecute(object sender, CanExecuteRoutedEventArgs e) => e.CanExecute = int.TryParse(data.SelectedCorpus.CountMinLen, out int minLen) && int.TryParse(data.SelectedCorpus.CountMaxLen, out int maxLen) && int.TryParse(data.SelectedCorpus.CountMinFreq, out int minFreq) && 0 < minLen && minLen <= maxLen && minFreq > 0;

        private void SearchCmdExecuted(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void SearchCmdCanExecute(object sender, CanExecuteRoutedEventArgs e) => e.CanExecute = data.SelectedCorpus.SearchContent != "" && int.TryParse(data.SelectedCorpus.SearchLeftLen, out int leftLen) && int.TryParse(data.SelectedCorpus.SearchRightLen, out int rightLen) && leftLen >= 0 && rightLen >= 0;

        private void SaveAllCmdExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            CorpusInfo currentCorpus = data.SelectedCorpus;
            foreach (CorpusInfo item in data.CorpusCollection)
            {
                if (!item.Unsaved) continue;
                data.SelectedCorpus = item;
                SaveCmdExecuted(sender, e);
            }
            data.SelectedCorpus = currentCorpus;
        }

        private void SaveAllCmdCanExecute(object sender, CanExecuteRoutedEventArgs e) => e.CanExecute = data.CorpusCollection.Any(corpus => corpus.Unsaved);

        private void AboutCmdExecuted(object sender, ExecutedRoutedEventArgs e) => MessageBox.Show("Corpus Studio\r\n版本：2\r\n作者：王启星", "关于");

        private void MainWindowClosing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            ExitCmdExecuted(sender, null);
        }

        private void TextFileUnselectAllCmdExecuted(object sender, ExecutedRoutedEventArgs e) => (e.Parameter as ListView).UnselectAll();

        private void TextFileUnselectAllCmdCanExecute(object sender, CanExecuteRoutedEventArgs e) => e.CanExecute = ((e.Parameter as ListView)?.SelectedItems.Count ?? 0) > 0;

        private void TextFileChooseUtf8EncodingCmdExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            (e.Parameter as ListView).SelectedItems.OfType<TextFile>().AsParallel().ForAll(textFile => textFile.Encoding = "UTF-8");
            data.SelectedCorpus.Unsaved = true;
        }

        private void TextFileChooseUtf8EncodingCmdCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (((e.Parameter as ListView)?.SelectedItems.Count ?? 0) == 0)
            {
                e.CanExecute = false;
                return;
            }
            e.CanExecute = (e.Parameter as ListView).SelectedItems.OfType<TextFile>().AsParallel().All(textFile => textFile.MayBeUtf8Encoded()) && (e.Parameter as ListView).SelectedItems.OfType<TextFile>().AsParallel().Any(textFile => textFile.Encoding != "UTF-8");
        }

        private void TextFileChooseGbEncodingCmdExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            (e.Parameter as ListView).SelectedItems.OfType<TextFile>().AsParallel().ForAll(textFile => textFile.Encoding = "GB");
            data.SelectedCorpus.Unsaved = true;
        }

        private void TextFileChooseGbEncodingCmdCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (((e.Parameter as ListView)?.SelectedItems.Count ?? 0) == 0)
            {
                e.CanExecute = false;
                return;
            }
            e.CanExecute = (e.Parameter as ListView).SelectedItems.OfType<TextFile>().AsParallel().All(textFile => textFile.MayBeGbEncoded()) && (e.Parameter as ListView).SelectedItems.OfType<TextFile>().AsParallel().Any(textFile => textFile.Encoding != "GB");
        }
    }
}
