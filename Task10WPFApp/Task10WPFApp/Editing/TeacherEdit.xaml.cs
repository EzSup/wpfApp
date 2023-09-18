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
    public partial class TeacherEdit : Page
    {
        private readonly ITeachersService _teachersService;
        public ObservableCollection<Teacher> Teachers { get; set; }
        public Teacher? SelectedTeacher { get; set; }

        public TeacherEdit(ITeachersService teachersService, Teacher? selectedTeacher)
        {
            _teachersService = teachersService;
            Teachers = new(_teachersService.GetAll());
            SelectedTeacher = selectedTeacher;
            InitializeComponent();
            UpdateFormData(SelectedTeacher);

            DataContext = this;
        }

        private void Select_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is Teacher teacher)
            {
                SelectedTeacher = teacher;
                UpdateFormData(SelectedTeacher);
            }
        }
        private void Set_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TeacherUpdateDto dto = new TeacherUpdateDto(SelectedTeacher.Id, txtFirstName.Text, txtLastName.Text);
                _teachersService.Update(dto);
                ClearForm();
                TeachersRefresh();
                MessageBox.Show("Data updated successfully", "Editing", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Editing exception", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void UpdateFormData(Teacher? teacher)
        {
            if (teacher != null)
            {
                txtFirstName.Text = teacher.Name;
                txtLastName.Text = teacher.Surname;
            }
        }
        private void ClearForm()
        {
            txtFirstName?.Clear();
            txtLastName?.Clear();
        }

        private void TeachersRefresh()
        {
            Teachers.Clear();
            var teachers = _teachersService.GetAll();
            foreach (var teacher in teachers)
            {
                Teachers.Add(teacher);
            }
        }
    }
}
