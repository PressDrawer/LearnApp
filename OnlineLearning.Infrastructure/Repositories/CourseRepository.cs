using Microsoft.EntityFrameworkCore;
using OnlineLearning.Application.Interfaces.RepositoryInterfaces;
using OnlineLearning.Domain.Models;
using OnlineLearning.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearning.Infrastructure.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly AppDbContext _context;
        public CourseRepository(AppDbContext context)
        {
            _context= context;  
        }

        public async Task<ICollection<Course>> GetCourses()
        {
            var courses = await _context.Courses.ToListAsync();
            return courses;
        }
        public async Task<Course> CreateCourse(Course course)
        {
            var _course = await _context.Courses.FirstOrDefaultAsync(c => c.CourseName == course.CourseName);
            if (_course == null) 
            {
                await _context.Courses.AddAsync(course);
                await _context.SaveChangesAsync();
                return course; 
            };
            return null;
        }
        public async Task<Course> UpdateCourse(Guid id, Course course)
        {
            var _course = _context.Courses.FirstOrDefault(c => c.CourseId == id);
            if (_course != null)
            {
                //_context.Entry(course).State = EntityState.Modified;
                _course.CourseName = string.IsNullOrEmpty(course.CourseName)? _course.CourseName:course.CourseName;
                _course.CourseCategory = string.IsNullOrEmpty(course.CourseCategory) ? _course.CourseCategory:course.CourseCategory;
                _course.CourseFee = (course.CourseFee != 0) ? course.CourseFee : _course.CourseFee;
                await _context.SaveChangesAsync();  
                return course;
            }
            return null;
        }
        public async Task<Course> GetCourse(Guid id)
        {
            var course = await _context.Courses.FirstOrDefaultAsync(c=>c.CourseId==id);
            if (course != null) return course;
            
            return null;
        }

        public async Task<Course> DeleteCourse(Guid id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course != null)
            {
                _context.Courses.Remove(course);
                await _context.SaveChangesAsync();
                return course;
            }
            return null;
            
        }

    }
}
