using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task10WPFApp.Core.Models;
using Task10WPFApp.Core.Repositories.Interfaces;
using Task10WPFApp.Core.Services.Interfaces;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using Task10WPFApp.Core.Models.DTOs;

namespace Task10WPFApp.Core.Services
{
    public class StudentsService : IStudentsService
    {
        private readonly IStudentsRepository _studentsRepository;

        public StudentsService(IStudentsRepository studentsService)
        {
            _studentsRepository = studentsService;
        }

        public List<Student> GetAll() => _studentsRepository.GetAll();
        public List<Student>? GetAll(int groupId) => GetAll().Where(g => g.GroupId == groupId).ToList();
        public Student? Get(int studentId) => _studentsRepository.Get(studentId);

        public void Delete(int studentId) => _studentsRepository.Delete(studentId);
        public void Update(StudentUpdateDto dto) => _studentsRepository.Update(dto);
        public void Add(StudentCreateDto dto) => _studentsRepository.Add(dto);

        public void ExportToCSV(List<Student> students, string filePath)
        {
            using(var writer = new StreamWriter(filePath))
            using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture) { Delimiter = ","}))
            {
                csv.WriteRecords(students);
            }
        }

        public void ExportToCSV(int groupId, string filePath)
        {
            List<Student> students = GetAll().Where(student => student.GroupId == groupId).ToList();
            ExportToCSV(students, filePath);
        }

        public void ImportFromCSV(int groupId, string filePath)
        {
            if (GetAll().Select(student => student.GroupId).Contains(groupId))
            {
                throw new Exception("The group must be empty before importing students");
            }
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture) { Delimiter = "," }))
            {
                var importedStudents = csv.GetRecords<Student>().ToList();

                foreach(var student in importedStudents)
                {
                    student.GroupId = groupId;
                    if (String.IsNullOrEmpty(student.Name) || string.IsNullOrEmpty(student.Surname))
                    {
                        throw new ArgumentNullException("Student`s name and surname do not math the format");
                    }
                    var dto = new StudentCreateDto(groupId, student.Name, student.Surname);
                    Add(dto);
                }
            }
        }

        
    }
}
