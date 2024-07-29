using OnlineLearning.Application.Dtos;
using OnlineLearning.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearning.Application.Interfaces.ServiceInterfaces
{
    public interface IStudentService
    {
        public Task<Student> GetStudent(Guid id);
        public Task<IEnumerable<Student>> GetAllStudents();
        public Task<Student> AddStudent(Student student);
        public Task<Student> UpdateStudent(Student student, Guid id);
        public Task<Student> DeleteStudent(Guid id);
        public Task<ICollection<CourseView>> GetEnrolledCources(Guid id);
        public Task<EnrollmentDto> EnrollCourses(EnrollmentDto enroll);
    }
}
