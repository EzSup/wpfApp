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
    public class Course
    {
        [Key]
        [Column("COURSE_ID")]
        public int Id { get; set; }

        [DisplayName("Name")]
        [Column("NAME")]
        public string Name { get; set; }

        [DisplayName("Description")]
        [Column("DESCRIPTION")]
        public string Description { get; set; }
    }
}
