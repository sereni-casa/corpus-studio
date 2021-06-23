using Microsoft.Data.Sqlite;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using System.Text.Json;
using System.Windows;
using System.Windows.Input;

namespace CorpusStudio
{
    /// <summary>
    /// OutputWindow.xaml 的交互逻辑
    /// </summary>
    public partial class OutputWindow : Window
    {
        public static readonly RoutedCommand SaveCmd = new();
        public OutputWindow(string name)
        {
            InitializeComponent();
            DataContext = new OutputWindowData(name);
        }

        public void SetDataToOutput(ObservableCollection<object> dataToOutput) => (DataContext as OutputWindowData).DataToOutput = dataToOutput;

        private void CanSave(object sender, CanExecuteRoutedEventArgs e) => e.CanExecute = ((DataContext as OutputWindowData).DataToOutput?.Count ?? 0) > 0;


        private void Save(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog dialog = new() { Filter = (e.Parameter as string) switch { "json" => "JSON 文本|*.json", "sqlite" => "SQLite 数据库|*.db", _ => "" } };
            if (dialog.ShowDialog() != true) return;
            while (File.Exists(dialog.FileName))
            {
                try
                {
                    File.Delete(dialog.FileName);
                }
                catch (Exception)
                {
                    if (MessageBox.Show($"无法删除原有文件：{dialog.FileName}\r\n是否重试？", "覆盖文件", MessageBoxButton.YesNo) == MessageBoxResult.No) return;
                }
            }
            if ((e.Parameter as string) == "json")
            {
                File.WriteAllBytes(dialog.FileName, JsonSerializer.SerializeToUtf8Bytes((DataContext as OutputWindowData).DataToOutput));
                return;
            }
            if ((e.Parameter as string) == "sqlite")
            {
                using SqliteConnection connection = new($"Data Source={dialog.FileName}");
                connection.Open();
                using SqliteTransaction transaction = connection.BeginTransaction();
                SqliteCommand createSqlCmd = connection.CreateCommand();
                List<PropertyInfo> propertyList = new((DataContext as OutputWindowData).DataToOutput[0].GetType().GetProperties());
                createSqlCmd.CommandText = $"CREATE TABLE {(DataContext as OutputWindowData).Name} ( {string.Join(" , ", propertyList.ConvertAll(property => property.Name))} )";
                createSqlCmd.ExecuteNonQuery();
                foreach (object datum in (DataContext as OutputWindowData).DataToOutput)
                {
                    SqliteCommand insertSqlCmd = connection.CreateCommand();
                    insertSqlCmd.CommandText = $"INSERT INTO {(DataContext as OutputWindowData).Name} VALUES ( {string.Join(" , ", propertyList.ConvertAll(property => $"${property.Name}"))} )";
                    propertyList.ForEach(property => insertSqlCmd.Parameters.AddWithValue($"${property.Name}", property.GetValue(datum)));
                    insertSqlCmd.ExecuteNonQuery();
                }
                transaction.Commit();
                return;
            }
        }
    }
}
