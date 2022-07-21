using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using ShareTypes.JsonAdapter;

namespace StandardEditor
{
    
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<ActionStation> standardStepsList = new ObservableCollection<ActionStation>();
        string filePath = "";
        public delegate Point GetPosition(IInputElement element);
        int rowIndex = 1;

        public MainWindow()
        {
            InitializeComponent();
            dataGrid.ItemsSource = standardStepsList;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            dlg.DefaultExt = ".json";
            dlg.Filter = "JSON Files (*.json)|*.json";

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                string fileName = dlg.FileName;
                textBoxFilePath.Text = dlg.SafeFileName;
                filePath = fileName;

                LoadStandardFromFile(fileName);
            }
        }

        private void LoadStandardFromFile(string path)
        {
            var standard = StationAdapterJson.GetNormativ(path);
            foreach (var item in standard) standardStepsList.Add(item);

        }

        private void BtnSaveStandard_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var newStandard = new List<ActionStation>(standardStepsList);
                StationAdapterJson.CreateStandard(newStandard, filePath);
                MessageBox.Show("Успешно сохранено.");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Произошла ошибка.");
            }
        }

        private void UpRowBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!(dataGrid.SelectedItem is ActionStation))
                return;

            int index = dataGrid.SelectedIndex;
            if (index == 0)
                return;
            
            int removeIndex = index - 1;

            standardStepsList.Move(index, removeIndex);
        }

        private void DownRowBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!(dataGrid.SelectedItem is ActionStation))
                return;

            int index = dataGrid.SelectedIndex;
            
            if (index == standardStepsList.Count - 1)
                return;
            int removeIndex = index + 1;

            standardStepsList.Move(index, removeIndex);
        }
    }
}
