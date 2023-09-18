using Task10WPFApp.Core.Models;
using Task10WPFApp.Core.Services;
using Task10WPFApp.Core.Services.Interfaces;
using Task10WPFApp.Core;
using Microsoft.EntityFrameworkCore;
using Task10WPFApp.Core.Repositories;
using System.Windows;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using System.IO;
using System;

namespace Task10WPFApp
{
    public partial class App : Application
    {
        private UniversityDbContext _dbContext;

        protected override void OnStartup(StartupEventArgs e)
        {
            var dbContextFactory = new UniversityDbContextFactory();
            _dbContext = dbContextFactory.CreateDbContext(null);
            _dbContext.Database.Migrate();

            var groupsRepository = new GroupsRepository(_dbContext);
            var studentsRepository = new StudentsRepository(_dbContext);
            var coursesRepository = new CoursesRepository(_dbContext);
            var teachersRepository = new TeachersRepository(_dbContext);

            var _coursesService = new CoursesService(coursesRepository);
            var _groupsService = new GroupsService(groupsRepository, studentsRepository, coursesRepository, teachersRepository);
            var _studentsService = new StudentsService(studentsRepository);
            var _teachersService = new TeachersService(teachersRepository);

            var mainWindow = new MainWindow(_coursesService, _groupsService, _studentsService, _teachersService);
            mainWindow.Show();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _dbContext.Dispose();
            base.OnExit(e);
        }
    }
}
