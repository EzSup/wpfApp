using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task10WPFApp.Core.Models.DTOs
{
    public class StudentUpdateDto
    {
        public int StudentId { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public StudentUpdateDto(int studentId, string? name, string? surname)
        {
            Name = name;
            Surname = surname;
            if (!Regex.IsMatch(name, Limitations.NameOrSurname))
            {
                Name = null;
            }
            if (!Regex.IsMatch(surname, Limitations.NameOrSurname))
            {
                Surname=null;
            }
            StudentId = studentId;
            
        }
    }
}
