using OnlineLearning.Application.Dtos;
using OnlineLearning.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearning.Application.Interfaces.RepositoryInterfaces
{
    public interface IStudentRepository
    {
        public Task<ICollection<Student>> GeStudents();
        public Task<Student> GetStudent(Guid id);
        public Task<Student> CreateStudent(Student student);
        public Task<Student> UpdateStudent(Guid id, Student student);
        public Task<Student> DeleteStudent(Guid id);
        public Task<ICollection<CourseView>> EnrolledCources(Guid id);

        public Task<EnrollmentDto> EnrollForCourses(EnrollmentDto enrollDto);

    }
}
