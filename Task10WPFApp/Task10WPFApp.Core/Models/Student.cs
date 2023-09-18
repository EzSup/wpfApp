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
    public class Student
    {
        [Key]
        [Column("STUDENT_ID")]
        public int Id { get; set; }

        [DisplayName("Group id")]
        [Column("GROUP_ID")]
        public int GroupId { get; set; }

        [DisplayName("Name")]
        [Column("FIRST_NAME")]
        public string? Name { get; set; }

        [DisplayName("Surname")]
        [Column("SECOND_NAME")]
        public string? Surname { get; set; }

    }
}
