using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDWithIssuesCore.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [Required]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
    }
}
