using System.Net;
using System.Security.Cryptography;
using Task10WPFApp.Core.Models;
using Task10WPFApp.Core.Repositories.Interfaces;
using Xceed.Words.NET;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.Diagnostics;
using Xceed.Document.NET;
using System.Drawing;
using Task10WPFApp.Core.Models.DTOs;

namespace Task10WPFApp.Core.Repositories
{
    public class GroupsRepository : IGroupsRepository
    {
        private readonly UniversityDbContext _dbContext;

        public GroupsRepository(UniversityDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Group> GetAll()
        {
            return _dbContext.Groups.ToList();
        }

        public Group? Get(int groupId)
        {
            return _dbContext.Groups.Find(groupId);
        }

        public void Update(GroupUpdateDto dto)
        {
            Group group = Get(dto.GroupId);
            if (group is null)
            {
                throw new NullReferenceException("Not found");
            }
            group.TeacherID = dto.TeacherId ?? group.TeacherID;
            if (dto.Name != null)
            {
                group.Name = dto.Name;
            }
            SaveChanges();
        }

        public bool HasStudentsInGroup(int groupId)
        {
            return _dbContext.Students.Any(s => s.GroupId == groupId);
        }

        public void Delete(int groupId)
        {
            var group = _dbContext.Groups.Find(groupId);
            if(group is null)
            {
                throw new NullReferenceException("Not found");
            }
            if(HasStudentsInGroup(groupId))
            {
                throw new Exception("You cannot delete a group if there are students in it");
            }
            _dbContext.Groups.Remove(group);
            SaveChanges();
        }


        public void Add(GroupCreateDto dto)
        {
            if (_dbContext.Courses.Find(dto.CourseId) is null || _dbContext.Teachers.Find(dto.TeacherId) is null)
            {
                throw new ArgumentException("Teacher or course doesn`t exist");
            }
            Group group = new() { CourseId = dto.CourseId, TeacherID = dto.TeacherId, Name = $"{_dbContext.Courses.Find(dto.CourseId).Name}-{dto.Name}" };
            _dbContext.Groups.Add(group);
            SaveChanges();
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
