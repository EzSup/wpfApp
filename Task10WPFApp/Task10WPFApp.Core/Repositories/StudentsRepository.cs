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
    public class StudentsRepository : IStudentsRepository
    {
        private readonly UniversityDbContext _dbContext;
        public StudentsRepository(UniversityDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Student> GetAll()
        {
            return _dbContext.Students.ToList();
        }
        public List<Student> GetAll(int groupID)
        {
            return _dbContext.Students.Where(student => student.GroupId == groupID).ToList();
        }

        public Student? Get(int studentId)
        {
            return _dbContext.Students.Find(studentId);
        }

        public void Update(StudentUpdateDto dto)
        {
            var student = Get(dto.StudentId);
            if (student == null)
            {
                throw new NullReferenceException("Not found");
            }
            student.Name = dto.Name ?? student.Name;
            student.Surname = dto.Surname ?? student.Surname;
            SaveChanges();
        }

        public void Delete(int studentId)
        {
            var student = _dbContext.Students.Find(studentId);
            if (student is null)
            {
                throw new NullReferenceException("Not found");
            }
            _dbContext.Students.Remove(student);
            SaveChanges();
        }

        public void Add(StudentCreateDto dto)
        {
            Group group = _dbContext.Groups.Find(dto.GroupId) 
                ?? throw new ArgumentException("Group with this Id doesn`t exist");
            Student student = new Student() { Name = dto.Name, Surname = dto.Surname, GroupId = dto.GroupId};
            _dbContext.Students.Add(student);
            SaveChanges();
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
