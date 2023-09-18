using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
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
using Task10WPFApp.Core.Services;
using Task10WPFApp.Core.Services.Interfaces;
using Task10WPFApp.Core;
using Microsoft.EntityFrameworkCore;
using Task10WPFApp.Core.Repositories;
using System.Collections.ObjectModel;
using Microsoft.Win32;

namespace Task10WPFApp
{
    public partial class DataDisplay : Page
    {
        private readonly ICoursesService _coursesService;
        private readonly IGroupsService _groupsService;
        private readonly IStudentsService _studentsService;
        private readonly ITeachersService _teachersService;
        public ObservableCollection<Course> Courses { get; set; }
        public ObservableCollection<Task10WPFApp.Core.Models.Group> Groups { get; set; }
        public ObservableCollection<Student> Students { get; set; }
        public ObservableCollection<Teacher> Teachers { get; set; }
        public DataDisplay(ICoursesService coursesService, IGroupsService groupsService, IStudentsService studentsService, ITeachersService teachersService)
        {
            InitializeComponent();
            _coursesService = coursesService;
            _groupsService = groupsService;
            _studentsService = studentsService;
            _teachersService = teachersService;
            LoadData();
            this.DataContext = this;
        }
        private void LoadData()
        {
            Courses = new(_coursesService.GetAll());
            Teachers = new(_teachersService.GetAll());
            Groups = new();
            Students = new();
            
        }
        private void SelectCourse_Click(object sender, RoutedEventArgs e)
        {
            Students.Clear();
            if (sender is Button button && button.DataContext is Course selectedCourse)
            {
                var groups = _groupsService.GetAll(selectedCourse.Id);

                Groups.Clear();
                foreach (var group in groups)
                {
                    Groups.Add(group);
                }
            }

        }
        private void SelectGroup_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is Group selectedGroup)
            {
                var students = _studentsService.GetAll(selectedGroup.Id);
                Students.Clear();
                foreach (var student in students)
                {
                    Students.Add(student);
                }
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                if (button.DataContext is Student student)
                {
                    Page studentEditPage = new StudentEdit(_studentsService, _groupsService.GetAll(), student);
                    NavigationService.Navigate(studentEditPage);
                }
                if (button.DataContext is Group group)
                {
                    Page groupEditPage = new GroupEdit(_groupsService, _teachersService.GetAll(), group);
                    NavigationService.Navigate(groupEditPage);
                }
                if (button.DataContext is Teacher teacher)
                {
                    Page studentEditPage = new TeacherEdit(_teachersService, teacher);
                    NavigationService.Navigate(studentEditPage);
                }
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                if (button.DataContext is Group selectedGroup)
                {
                    DeleteItem(selectedGroup, Groups, (group) => _groupsService.Delete(group.Id));
                }
                if (button.DataContext is Student selectedStudent)
                {
                    DeleteItem(selectedStudent, Students, (student) => _studentsService.Delete(student.Id));
                }
                if (button.DataContext is Teacher selectedTeacher)
                {
                    DeleteItem(selectedTeacher, Teachers, (teacher) => _teachersService.Delete(teacher.Id));
                }
            }
        }

        private void TreeView_Click(object sender, RoutedEventArgs e)
        {
            var coursesWithGroups = new ObservableCollection<CourseWithGroups>();
            foreach (var course in Courses)
            {
                var groups = new List<Group>(_groupsService.GetAll(course.Id));
                coursesWithGroups.Add(new CourseWithGroups() { Course = course, Groups = groups });
            }
            var treeview = new TreeView(coursesWithGroups, _groupsService.GetAll());
            treeview.Show();
        }

        private void DeleteItem<T>(T selectedItem, ObservableCollection<T> collection, Action<T> deleteAction) where T : class
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete the record?", "Confirmation of deletion", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    deleteAction(selectedItem);
                    collection.Remove(selectedItem);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Deleting exception", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
