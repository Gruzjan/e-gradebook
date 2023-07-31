using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DzienniczekE.Data.Tables
{
    public class Grade
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GradeId { get; set; }
        [Required]
        public int Value { get; set; }
        [Required]
        public int Weight { get; set; } = 1;

        //relations
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
    }
}
