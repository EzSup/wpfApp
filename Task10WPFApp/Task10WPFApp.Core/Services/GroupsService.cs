using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task10WPFApp.Core.Models;
using Task10WPFApp.Core.Repositories;
using Task10WPFApp.Core.Repositories.Interfaces;
using Task10WPFApp.Core.Services.Interfaces;
using Task10WPFApp.Core.Models.DTOs;
using CsvHelper;
using System.Globalization;
using Microsoft.EntityFrameworkCore;
using PdfSharp.Drawing;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace Task10WPFApp.Core.Services
{
    public class GroupsService : IGroupsService
    {
        private readonly IGroupsRepository _groupsRepository;
        private readonly IStudentsRepository _studentsRepository;
        private readonly ICoursesRepository _coursesRepository;
        private readonly ITeachersRepository _teachersRepository;

        public GroupsService(IGroupsRepository groupsRepository, IStudentsRepository studentsRepository, ICoursesRepository coursesRepository, ITeachersRepository teachersRepository)
        {
            _groupsRepository = groupsRepository;
            _studentsRepository = studentsRepository;
            _coursesRepository = coursesRepository;
            _teachersRepository = teachersRepository;
        }

        public List<Group> GetAll() => _groupsRepository.GetAll();
        public List<Group>? GetAll(int courseId) => GetAll().Where(g => g.CourseId == courseId).ToList();
        public Group? Get(int id) => _groupsRepository.Get(id);

        public void Delete(int groupId) => _groupsRepository.Delete(groupId);
        public void Update(GroupUpdateDto dto) =>  _groupsRepository.Update(dto);
        public void Add(GroupCreateDto dto) => _groupsRepository.Add(dto);

        public void CreateDocxDocument(int groupId, string filePath)
        {
            Group group = Get(groupId);
            if (group is null)
            {
                throw new ArgumentNullException("Group not found");
            }
            List<Student> students = _studentsRepository.GetAll(group.Id);
            Course course = _coursesRepository.Get(group.CourseId);
            Teacher teacher = _teachersRepository.Get(group.TeacherID);

            using (DocX doc = DocX.Create(filePath))
            {
                doc.SetDefaultFont(new Xceed.Document.NET.Font("Times New Roman"));

                doc.InsertParagraph($"Course: {course.Name}").FontSize(20).Bold().Alignment = Alignment.center;
                doc.InsertParagraph($"Group: {group.Name}").FontSize(20).Bold().Alignment = Alignment.center;
                doc.InsertParagraph("Teacher:").FontSize(15).Bold().
                    Append($"{teacher.Name} {teacher.Surname}").FontSize(15).Italic();
                doc.InsertParagraph("Students list:").FontSize(15).Bold();

                int i = 1;
                foreach (var student in students)
                {
                    doc.InsertParagraph($"{i}. {student.Name} {student.Surname}").FontSize(12).Italic();
                    i++;
                }

                doc.Save();
            }
        }

        public void CreatePdfDocument(int groupId, string filePath)
        {
            Group group = Get(groupId);
            if (group is null)
            {
                throw new ArgumentNullException("Group not found");
            }
            List<Student> students = _studentsRepository.GetAll(group.Id);
            Course course = _coursesRepository.Get(group.CourseId);
            Teacher teacher = _teachersRepository.Get(group.TeacherID);

            var doc = new PdfSharp.Pdf.PdfDocument();
            var page = doc.AddPage();

            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont headlineFont = new XFont("Times New Roman", 20, XFontStyle.Bold);
            XFont teacherLineFont = new XFont("Times New Roman", 15, XFontStyle.Bold);
            XFont teacherNameFont = new XFont("Times New Roman", 15, XFontStyle.Italic);
            XFont lineFont = new XFont("Times New Roman", 15, XFontStyle.Bold);
            XFont studentLineFont = new XFont("Times New Roman", 12, XFontStyle.Italic);

            gfx.DrawString($"Course: {course.Name}", headlineFont, XBrushes.Black,
                new XRect(0, 20, page.Width, page.Height), XStringFormats.TopCenter);
            gfx.DrawString($"Group: {group.Name}", headlineFont, XBrushes.Black,
                new XRect(0, 50, page.Width, page.Height), XStringFormats.TopCenter);
            gfx.DrawString("Teacher:", teacherLineFont, XBrushes.Black,
               new XRect(30, 120, page.Width, 0), XStringFormats.BaseLineLeft);
            gfx.DrawString($"{teacher.Name} {teacher.Surname}", teacherNameFont, XBrushes.Black,
               new XRect(100, 120, page.Width, 0), XStringFormats.BaseLineLeft);
            gfx.DrawString($"Students list:", lineFont, XBrushes.Black,
               new XRect(30, 140, page.Width, 0), XStringFormats.BaseLineLeft);
            int x = 30, y = 160, deltaY = 20, i = 1;
            foreach (var student in students)
            {
                gfx.DrawString($"{i}.{student.Name} {student.Surname}", studentLineFont, XBrushes.Black,
               new XRect(x, y, page.Width, 0), XStringFormats.BaseLineLeft);
                y += deltaY;
                i++;
            }

            doc.Save(filePath);
        }

    }
}
