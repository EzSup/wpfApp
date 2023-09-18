using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task10WPFApp.Core.Models
{
    public class CourseWithGroups
    {
        public Course Course { get; set; }
        public List<Group> Groups { get; set; }
    }
}
