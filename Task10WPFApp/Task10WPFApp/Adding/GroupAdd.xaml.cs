using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
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
using Task10WPFApp.Core.Services;
using Task10WPFApp.Core.Services.Interfaces;
using Task10WPFApp.Core.Models.DTOs;

namespace Task10WPFApp
{
    public partial class GroupAdd : Page
    {
        private readonly IGroupsService _groupService;
        List<Course> Courses = new List<Course>();
        List<Teacher> Teachers = new List<Teacher>();
        public GroupAdd(IGroupsService groupService, List<Course> courses, List<Teacher> teachers)
        {
            _groupService = groupService;
            Courses = courses;
            Teachers = teachers;
            InitializeComponent();
            cmbCourses.ItemsSource = Courses.Select(course => course.Name);
            cmbTeachers.ItemsSource = Teachers.Select(teacher => $"{teacher.Name} {teacher.Surname}");
        }

        public void Save_Click(object sender, RoutedEventArgs e)
        {
            if (cmbCourses.SelectedItem == null || cmbTeachers.SelectedItem == null)
            {
                MessageBox.Show("Course or teacher is not selected", "Creating exception", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            int courseId = Courses.Find(course => course.Name == cmbCourses.SelectedItem.ToString()).Id;
            int teacherId = Teachers.Find(teacher => $"{teacher.Name} {teacher.Surname}" == cmbTeachers.SelectedItem.ToString()).Id;
            try
            {
                _groupService.Add(new GroupCreateDto(txtName.Text, courseId, teacherId));
                MessageBox.Show("Group added successfully", "Creating", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Creating exception", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            ClearForm();
        }

        private void ClearForm()
        {
            txtName?.Clear();
            cmbCourses.SelectedItem = null;
            cmbTeachers.SelectedItem = null;
        }
    }
}
