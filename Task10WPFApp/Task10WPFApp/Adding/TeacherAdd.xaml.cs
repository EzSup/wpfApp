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
using Task10WPFApp.Core.Repositories.Interfaces;
using Task10WPFApp.Core.Services.Interfaces;
using Task10WPFApp.Core.Models.DTOs;

namespace Task10WPFApp
{
    public partial class TeacherAdd : Page
    {
        private readonly ITeachersService _teachersService;
        public TeacherAdd(ITeachersService teachersService)
        {
            _teachersService = teachersService;
            InitializeComponent();
        }
        public void Save_Click(object sender, RoutedEventArgs e)
        {
            try 
            { 
                _teachersService.Add(new TeacherCreateDto(txtFirstName.Text, txtLastName.Text));
                MessageBox.Show("Teacher added successfully", "Creating", MessageBoxButton.OK, MessageBoxImage.Information);
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
        }
    }
}
