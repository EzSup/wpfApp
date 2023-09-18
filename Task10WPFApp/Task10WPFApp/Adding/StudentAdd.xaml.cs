using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
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
using Task10WPFApp.Core.Models;
using Task10WPFApp.Core.Services.Interfaces;
using Task10WPFApp.Core.Models.DTOs;

namespace Task10WPFApp
{
    public partial class StudentAdd : Page
    {
        private readonly IStudentsService _studentsService;
        public List<Group> Groups { get; set; }
        public StudentAdd(IStudentsService studentsService, List<Group> groups)
        {
            _studentsService = studentsService;
            Groups = groups;
            InitializeComponent();
            cmbGroups.ItemsSource = Groups.Select(group => group.Name);
        }

        public void Save_Click(object sender, RoutedEventArgs e)
        {
            if (cmbGroups.SelectedItem == null) 
            {
                MessageBox.Show("Group is not selected", "Creating exception", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            int groupId = Groups.First(group => group.Name == cmbGroups.SelectedItem.ToString()).Id ;
            try
            {
                _studentsService.Add(new StudentCreateDto(groupId, txtFirstName.Text, txtLastName.Text));
                MessageBox.Show("Student added successfully", "Creating", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Creating exception", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            ClearForm();
        }

        private void ClearForm()
        {
            txtFirstName?.Clear();
            txtLastName?.Clear();
            cmbGroups.SelectedItem = null;
        }
    }
}
