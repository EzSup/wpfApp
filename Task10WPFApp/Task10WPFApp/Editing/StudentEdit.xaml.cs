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
using Task10WPFApp.Core.Services.Interfaces;

namespace Task10WPFApp
{
    public partial class StudentEdit : Page
    {
        private readonly IStudentsService _studentsService;
        public List<Group> Groups { get; set; }
        public ObservableCollection<Student> Students { get; set; }
        public Student? SelectedStudent { get; set; }

        public StudentEdit(IStudentsService studentsService, List<Group> groups, Student? selectedStudent)
        {
            _studentsService = studentsService;
            Students = new(_studentsService.GetAll());
            Groups = groups;
            SelectedStudent = selectedStudent;
            InitializeComponent();
            UpdateFormData(SelectedStudent);

            DataContext = this;
        }

        private void Select_Click(object sender, RoutedEventArgs e)
        {
            if(sender is Button button && button.DataContext is Student student)
            {
                SelectedStudent = student;
                UpdateFormData(SelectedStudent);
            }
        }
        private void Set_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StudentUpdateDto dto = new StudentUpdateDto(SelectedStudent.Id, txtFirstName.Text, txtLastName.Text);
                _studentsService.Update(dto);
                ClearForm();
                StudentsRefresh();
                MessageBox.Show("Data updated successfully", "Editing", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Editing exception", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void UpdateFormData(Student? student)
        {
            if (student != null)
            {
                txtFirstName.Text = student.Name;
                txtLastName.Text = student.Surname;
            }
        }
        private void ClearForm()
        {
            txtFirstName?.Clear();
            txtLastName?.Clear();
        }

        private void StudentsRefresh()
        {
            Students.Clear();
            var students = _studentsService.GetAll();
            foreach (var student in students)
            {
                Students.Add(student);
            }
        }
    }
}
