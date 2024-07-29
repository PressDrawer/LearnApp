using OnlineLearning.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearning.Application.Interfaces.ServiceInterfaces
{
    public interface ICourseService
    {
        public Task<Course> GetCourse(Guid id);
        public Task<IEnumerable<Course>> GetAllCourses();
        public Task<Course> AddCourse(Course course);
        public Task<Course> UpdateCourse(Course course, Guid id);
        public Task<Course> DeleteCourse(Guid id);

    }
}
