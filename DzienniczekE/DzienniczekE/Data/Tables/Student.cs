using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DzienniczekE.Data.Tables
{
    public class Student
    {
        [Required]
        public int StudentId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        //relations
        public virtual List<Grade> Grades { get; set; }
        [NotMapped]
        public string FullName { get => $"{FirstName} {LastName}"; }
    }
}
