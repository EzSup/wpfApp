using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Task10WPFApp.Core.Services;
using Task10WPFApp.Core.Models;
using Task10WPFApp.Core.Services.Interfaces;

namespace Task10WPFApp
{
    public partial class GroupExportAndImport : Page
    {
        private readonly IStudentsService _studentsService;
        private readonly List<Group> _groups;
        public GroupExportAndImport(IStudentsService studentsService, List<Group> groups)
        {
            _studentsService = studentsService;
            _groups = groups;
            InitializeComponent();
            cmbGroups.ItemsSource = _groups.Select(group => group.Name);
        }

        public void Export_Click(object sender, RoutedEventArgs e)
        {
            Group group = _groups.Find(group => group.Name == cmbGroups.SelectedItem);
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*";

            if (saveFileDialog.ShowDialog() == true)
            {
                string filePath = saveFileDialog.FileName;
                try
                {
                    _studentsService.ExportToCSV(group.Id, filePath);
                    MessageBox.Show("Group exported successfully!", "Export", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Export exception", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }


        }
        public void Import_Click(object sender, RoutedEventArgs e)
        {
            Group group = _groups.Find(group => group.Name == cmbGroups.SelectedItem);
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                try
                {
                    _studentsService.ImportFromCSV(group.Id, filePath);
                    MessageBox.Show("Group imported successfully!", "Import", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Import exception", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

        }
    }
}
