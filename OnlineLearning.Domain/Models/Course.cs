using System.ComponentModel.DataAnnotations;

namespace OnlineLearning.Domain.Models
{
    public class Course
    {
        [Key]
        public Guid CourseId { get; set; }
        [Required]
        public string CourseName { get; set; }
        [Required]
        public string CourseCategory { get; set; }
        [Required]
        public int CourseFee { get; set; }
        //public ICollection<Student> Students { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}