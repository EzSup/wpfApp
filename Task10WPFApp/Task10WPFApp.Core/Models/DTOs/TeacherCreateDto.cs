using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task10WPFApp.Core.Models.DTOs
{
    public class TeacherCreateDto
    {
        public string Name;
        public string Surname;
        public TeacherCreateDto(string name, string surname) 
        {
            if (!Regex.IsMatch(name, Limitations.NameOrSurname))
            {
                throw new ArgumentException("Teacher`s name doesn`t match pattern");
            }
            if (!Regex.IsMatch(surname, Limitations.NameOrSurname))
            {
                throw new ArgumentException("Teacher`s surname doesn`t match pattern");
            }
            Name = name;
            Surname = surname;
        }
    }
}
