using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearning.Domain.Models
{
    public class Student
    {
        [Key]
        public Guid StudentId { get; set; }
        [Required]
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public string Mobile { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        //public ICollection<Course> Courses { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
