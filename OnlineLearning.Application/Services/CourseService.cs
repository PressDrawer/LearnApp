using OnlineLearning.Application.Interfaces.RepositoryInterfaces;
using OnlineLearning.Application.Interfaces.ServiceInterfaces;
using OnlineLearning.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearning.Application.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepo;
        public CourseService(ICourseRepository courseRepo)
        {
               _courseRepo= courseRepo;
        }
        

        public async Task<IEnumerable<Course>> GetAllCourses()
        {
            var courses = await _courseRepo.GetCourses();
            return courses;
        }

        public async Task<Course> GetCourse(Guid id)
        {
            var course = await _courseRepo.GetCourse(id);  
            return course;  
        }
        public async Task<Course> AddCourse(Course course)
        {
            
            return await _courseRepo.CreateCourse(course);
        }
        public async Task<Course> UpdateCourse(Course course, Guid id)
        {
            return await _courseRepo.UpdateCourse(id,course);
        }

        public async Task<Course> DeleteCourse(Guid id)
        {
            return await _courseRepo.DeleteCourse(id);
        }
    }
}
