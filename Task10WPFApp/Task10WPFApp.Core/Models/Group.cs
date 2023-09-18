using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task10WPFApp.Core.Models
{
    public class Group
    {
        [Key]
        [Column("GROUP_ID")]
        public int Id { get; set; }

        [DisplayName("Course id")]
        [Column("COURSE_ID")]
        public int CourseId { get; set; }

        [DisplayName("Teacher id")]
        [Column("TEACHER_ID")]
        public int TeacherID { get; set; }

        [DisplayName("Name")]
        [Column("NAME")]
        public string Name { get; set; }
    }
}
