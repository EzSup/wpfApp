using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task10WPFApp.Core.Models.DTOs
{
    public class GroupCreateDto
    {
        public string Name { get; set; }
        public int TeacherId { get; set; }
        public int CourseId { get; set; }

        public GroupCreateDto(string name, int courseId, int teacherId) 
        {
            if (!Regex.IsMatch(name, Limitations.GroupShortName)) 
            { 
                throw new ArgumentNullException("Group Name doesn`t math pattern"); 
            }
            Name = name;
            TeacherId = teacherId;
            CourseId = courseId;
        }
    }
}
