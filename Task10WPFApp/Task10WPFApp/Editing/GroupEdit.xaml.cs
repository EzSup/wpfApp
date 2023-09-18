using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Task10WPFApp.Core.Models;
using Task10WPFApp.Core.Models.DTOs;
using Task10WPFApp.Core.Services;
using Task10WPFApp.Core.Services.Interfaces;

namespace Task10WPFApp
{
    
    public partial class GroupEdit : Page
    {
        private readonly IGroupsService _groupsService;
        public ObservableCollection<Group> Groups { get; set; }
        public List<Teacher> Teachers { get; set; }
        public Group? SelectedGroup { get; set; }
        public GroupEdit(IGroupsService groupsService, List<Teacher> teachers, Group? selectedGroup)
        {
            _groupsService = groupsService;
            Groups = new(_groupsService.GetAll());
            Teachers = teachers;
            SelectedGroup = selectedGroup;
            InitializeComponent();
            cmbTeachers.ItemsSource = Teachers.Select(teacher => $"{teacher.Name} {teacher.Surname}");
            UpdateFormData(SelectedGroup);

            DataContext = this;
        }

        private void Select_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is Group group)
            {
                SelectedGroup = group;
                UpdateFormData(SelectedGroup);
            }
        }

        private void Set_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int teacherID = Teachers.Find(teacher => $"{teacher.Name} {teacher.Surname}" == cmbTeachers.SelectedItem.ToString()).Id;
                GroupUpdateDto dto = new GroupUpdateDto(txtName.Text, SelectedGroup.Id, teacherID);
                _groupsService.Update(dto);
                ClearForm();
                GroupsRefresh();
                MessageBox.Show("Data updated successfully", "Editing", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Editing exception", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void UpdateFormData(Group? group)
        {
            if (group != null)
            {
                txtName.Text = group.Name;
                var selectedTeacher = Teachers.Find(teacher => teacher.Id == group.TeacherID);
                cmbTeachers.SelectedItem = $"{selectedTeacher.Name} {selectedTeacher.Surname}";
            }
        }
        private void ClearForm()
        {
            txtName?.Clear();
            cmbTeachers.SelectedItem = null;
        }

        private void GroupsRefresh()
        {
            Groups.Clear();
            var groups = _groupsService.GetAll();
            foreach (var group in groups)
            {
                Groups.Add(group);
            }
        }
    }
}
