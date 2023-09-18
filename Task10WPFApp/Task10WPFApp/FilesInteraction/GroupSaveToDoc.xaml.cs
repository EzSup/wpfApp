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
using Task10WPFApp.Core.Services.Interfaces;
using Task10WPFApp.Core.Models;
using System.Text.RegularExpressions;

namespace Task10WPFApp
{
    public partial class GroupSaveToDoc : Page
    {
        private readonly IGroupsService _groupsService;
        public GroupSaveToDoc(IGroupsService groupsService)
        {
            _groupsService = groupsService;
            InitializeComponent();
            cmbGroups.ItemsSource = _groupsService.GetAll().Select(group => group.Name);
        }
        
        public delegate void CreateDocDelegate(int groupId, string filePath);
        
        public void DOCX_Click(object sender, RoutedEventArgs e)
        {
            string filter = "DOCX Files (*.docx)|*.docx|All Files (*.*)|*.*";
            CreateDocDelegate action = _groupsService.CreateDocxDocument;
            CreateDocument(action, filter);
        }
        
        public void PDF_Click(object sender, RoutedEventArgs e)
        {
            string filter ="PDF Files (*.pdf)|*.pdf|All Files (*.*)|*.*";
            CreateDocDelegate action = _groupsService.CreatePdfDocument;
            CreateDocument(action, filter);
        }

        private void CreateDocument(CreateDocDelegate action, string filter)
        {
            var group = _groupsService.GetAll().Find(group => group.Name == cmbGroups.SelectedItem);
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = filter;
            if(saveFileDialog.ShowDialog() == true)
            {
                string filePath = saveFileDialog.FileName;
                try
                {
                    action(group.Id, filePath);
                    MessageBox.Show("File saved successfully", "Document writing", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Document writing exception", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
