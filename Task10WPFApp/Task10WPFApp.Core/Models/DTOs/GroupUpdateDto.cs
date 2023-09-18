using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task10WPFApp.Core.Models.DTOs
{
    public class GroupUpdateDto
    {
        public int GroupId { get; set; }
        public int? TeacherId { get; set; }
        public string? Name { get; set; }

        public GroupUpdateDto(string? name, int groupId, int teacherId)
        {
            Name = name;
            if (!Regex.IsMatch(name, Limitations.GroupFullName))
            {
                Name = null;
            }
            TeacherId = teacherId;
            GroupId = groupId;
        }
    }
}
