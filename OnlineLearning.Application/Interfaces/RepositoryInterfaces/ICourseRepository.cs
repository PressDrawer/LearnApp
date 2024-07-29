using OnlineLearning.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearning.Application.Interfaces.RepositoryInterfaces
{
    public interface ICourseRepository
    {
        public Task<ICollection<Course>> GetCourses();
        public Task<Course> GetCourse(Guid id);
        public Task<Course> CreateCourse(Course course);
        public Task<Course> UpdateCourse(Guid id,  Course course);
        public Task<Course> DeleteCourse(Guid id);
    }
}
