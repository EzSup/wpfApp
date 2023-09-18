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
using System.Windows.Shapes;
using Task10WPFApp.Core.Models;

namespace Task10WPFApp
{
    public partial class TreeView : Window
    {
        public ObservableCollection<CourseWithGroups> CoursesWithGroups;
        public ObservableCollection<Group> Groups;
        public TreeView(ObservableCollection<CourseWithGroups> coursesWithGroups, List<Group> groups)
        {
            InitializeComponent();
            CoursesWithGroups = coursesWithGroups;
            Groups = new(groups);
            treeView.ItemsSource = CoursesWithGroups;
        }
    }
}
