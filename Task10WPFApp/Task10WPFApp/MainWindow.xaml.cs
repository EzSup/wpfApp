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
using Task10WPFApp.Core.Models;
using Task10WPFApp.Core.Services.Interfaces;

namespace Task10WPFApp
{
    public partial class MainWindow : Window
    {
        private readonly ICoursesService _coursesService;
        private readonly IGroupsService _groupsService;
        private readonly IStudentsService _studentsService;
        private readonly ITeachersService _teachersService;

        public MainWindow(ICoursesService coursesService, IGroupsService groupsService, IStudentsService studentsService, ITeachersService teachersService)
        {
            InitializeComponent();
            _coursesService = coursesService;
            _groupsService = groupsService;
            _studentsService = studentsService;
            _teachersService = teachersService;
            GoToDataDisplayPage();
        }

        private void GoToDataDisplayPage()
        {
            Page secondPage = new DataDisplay(_coursesService, _groupsService, _studentsService, _teachersService);
            mainFrame.Navigate(secondPage);
        }

        public void HamburgerMenu_Click(object sender, RoutedEventArgs e)
        {
            GoToDataDisplayPage();
        }
        public void Menu_Click(object sender, RoutedEventArgs e)
        {
            if (sender is MenuItem menuItem && menuItem.Parent is MenuItem parentMenuItem)
            {
                Page nextPage = new Page();
                switch (parentMenuItem.Header, menuItem.Header)
                {
                    case ("Students", "New"):
                        nextPage = new StudentAdd(_studentsService, _groupsService.GetAll());
                        break;
                    case ("Students", "Edit"):
                        nextPage = new StudentEdit(_studentsService, _groupsService.GetAll(), null);
                        break;
                    case ("Groups", "New"):
                        nextPage = new GroupAdd(_groupsService, _coursesService.GetAll(), _teachersService.GetAll());
                        break;
                    case ("Groups", "Edit"):
                        nextPage = new GroupEdit(_groupsService, _teachersService.GetAll(), null);
                        break;
                    case ("Groups", "Export/Import"):
                        nextPage = new GroupExportAndImport(_studentsService, _groupsService.GetAll());
                        break;
                    case ("Groups", "Save to document"):
                        nextPage = new GroupSaveToDoc(_groupsService);
                        break;
                    case ("Teachers", "New"):
                        nextPage = new TeacherAdd(_teachersService);
                        break;
                    case ("Teachers", "Edit"):
                        nextPage = new TeacherEdit(_teachersService, null);
                        break;
                    default:
                        nextPage = new DataDisplay(_coursesService, _groupsService, _studentsService, _teachersService);
                        break;
                }
                mainFrame.Navigate(nextPage);
            }
        }
    }
}
