using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task10WPFApp.Core.Models.DTOs
{
    public class StudentCreateDto
    {
        public int GroupId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        
        public StudentCreateDto(int groupId, string name, string surname) 
        {
            if (!Regex.IsMatch(name, Limitations.NameOrSurname))
            {
                throw new ArgumentException("Student`s name doesn`t match pattern");
            }
            if (!Regex.IsMatch(surname, Limitations.NameOrSurname))
            {
                throw new ArgumentException("Student`s surname doesn`t match pattern");
            }
            GroupId = groupId;
            Name = name;
            Surname = surname;
        }
    }
}
