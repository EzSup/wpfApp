using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task10WPFApp.Core.Models
{
    public class Teacher
    {

        [Key]
        [Column("TEACHER_ID")]
        public int Id { get; set; }

        [DisplayName("Name")]
        [Column("FIRST_NAME")]
        public string? Name { get; set; }

        [DisplayName("Surname")]
        [Column("SECOND_NAME")]
        public string? Surname { get; set; }
    }
}
