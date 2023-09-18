using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task10WPFApp.Core.Models.DTOs
{
    public class TeacherUpdateDto
    {
        public int TeacherId { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public TeacherUpdateDto(int teacherId, string? name, string? surname)
        {
            Name = name;
            Surname = surname;
            if (!Regex.IsMatch(name, Limitations.NameOrSurname))
            {
                Name = null;
            }
            if (!Regex.IsMatch(surname, Limitations.NameOrSurname))
            {
                Surname = null;
            }
            TeacherId = teacherId;
        }
    }
}
