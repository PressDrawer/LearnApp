using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineLearning.Application.Dtos;
using OnlineLearning.Application.Interfaces.RepositoryInterfaces;
using OnlineLearning.Domain.Enum;
using OnlineLearning.Domain.Models;
using OnlineLearning.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearning.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;
        private readonly IAuthenticationRepository _authRepo;
        
        public StudentRepository(AppDbContext context, IAuthenticationRepository authRepo)
        {
            _context = context;
            _authRepo = authRepo;   
                
        }

        public async Task<ICollection<Student>> GeStudents()
        {
            var students = await _context.Students.ToListAsync();
            return (students);
        }

        public async Task<Student> GetStudent(Guid id)
        {
            var student = await _context.Students.FirstOrDefaultAsync(s=>s.StudentId== id);
            if(student!=null) return student;
            return null;
        }

        public async Task<Student> UpdateStudent(Guid id, Student student)
        {
            var _student = await _context.Students.FirstOrDefaultAsync(s=>s.StudentId==id);
            if (_student != null)
            {
                _student.Name = student.Name;
                _student.Age = student.Age;
                _student.Gender = student.Gender;
                _student.City = student.City;
                _student.Mobile = student.Mobile;
                _student.Email = student.Email;
                _student.Password = student.Password;
                _student.Gender = student.Gender;

                await _context.SaveChangesAsync();
                return student;
            }
            return null;
        }

        public async Task<Student> CreateStudent(Student student)
        {
            var _student = await _context.Students.FirstOrDefaultAsync(s => s.Email == student.Email);
            if (_student == null)
            {
                var id = Guid.NewGuid();
                student.StudentId= id;
                await _context.Students.AddAsync(student);
                var user = new User()
                {
                    UserId= id,
                    Email = student.Email,
                    Password = student.Password, 
                    Role = SystemRole.User
                };
                
                //await _context.Users.AddAsync(user);
                await _authRepo.UserRegister(user); 
                await _context.SaveChangesAsync();
                return student;
            };
            return null;
        }

        public async Task<Student> DeleteStudent(Guid id)
        {
            var student = _context.Students.FirstOrDefault(s => s.StudentId == id);
            var user = _context.Users.FirstOrDefault(u => u.Email == student.Email);
            if (student != null)
            {
                _context.Students.Remove(student);
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return student; 
            }
            return null;    
        }

        public async Task<ICollection<CourseView>> EnrolledCources(Guid id)
        {
            var studentswithCourses = from s in _context.Students
                                      join e in _context.Enrollments
                                      on s.StudentId equals e.StudentId
                                      join c in _context.Courses
                                      on e.CourseId equals c.CourseId
                                      where s.StudentId == id
                                      select new CourseView
                                      {
                                          CourseId = c.CourseId,
                                          CourseName = c.CourseName,
                                          CourseCategory = c.CourseCategory,
                                          Balance = e.Balance,
                                      };

         
            return await studentswithCourses.ToListAsync();
        }

        public async Task<EnrollmentDto> EnrollForCourses(EnrollmentDto enrollDto)
        {
            var courseFee = _context.Courses.Where(c => c.CourseId == enrollDto.CourseId).Select(c => c.CourseFee).FirstOrDefault();
            var _enroll = new Enrollment()
            {
                StudentId = enrollDto.StudentId,
                CourseId = enrollDto.CourseId,
                EnrollmentDate = DateTime.UtcNow,
                Downpayment = enrollDto.Downpayment,
                Balance = courseFee- enrollDto.Downpayment
            };
            var enroll = _context.Enrollments.FirstOrDefault(e => e.StudentId == enrollDto.StudentId && e.CourseId == enrollDto.CourseId);
            if (enroll == null)
            {
                await _context.Enrollments.AddAsync(_enroll);
                await _context.SaveChangesAsync();
                return enrollDto;
            }
            return null;
        }
    }
}
