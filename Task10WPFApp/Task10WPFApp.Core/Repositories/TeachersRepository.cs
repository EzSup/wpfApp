using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task10WPFApp.Core.Models;
using Task10WPFApp.Core.Models.DTOs;
using Task10WPFApp.Core.Repositories.Interfaces;

namespace Task10WPFApp.Core.Repositories
{
    public class TeachersRepository : ITeachersRepository
    {
        private readonly UniversityDbContext _dbContext;
        public TeachersRepository(UniversityDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Teacher> GetAll()
        {
            return _dbContext.Teachers.ToList();
        }


        public Teacher? Get(int teacherId)
        {
            return _dbContext.Teachers.Find(teacherId);
        }

        public void Add(TeacherCreateDto dto)
        {
            Teacher teacher = new() { Name = dto.Name, Surname = dto.Surname };
            _dbContext.Teachers.Add(teacher);
            SaveChanges();
        }

        public void Update(TeacherUpdateDto dto)
        {

            var teacher = Get(dto.TeacherId);
            if (teacher is null)
            {
                throw new NullReferenceException("Not found");
            }
            teacher.Name = dto.Name ?? teacher.Name;
            teacher.Surname = dto.Surname ?? teacher.Surname;
            SaveChanges();
        }

        public void Delete(int teacherId)
        {
            var teacher = _dbContext.Teachers.Find(teacherId);
            if (teacher is null)
            {
                throw new NullReferenceException("Not found");
            }
            if (AreGroupsWithThisTeacher(teacherId))
            {
                throw new Exception("You cannot delete a teacher if there are groups of it");
            }
            _dbContext.Teachers.Remove(teacher);
            SaveChanges();
        }

        private bool AreGroupsWithThisTeacher(int teacherId)
        {
            return _dbContext.Groups.Where(group => group.TeacherID == teacherId).ToList().Count > 0;
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
