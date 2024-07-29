using Microsoft.AspNetCore.Authorization;
using OnlineLearning.Application.Dtos;
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
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;        
        }

       
        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            return await _studentRepository.GeStudents();
        }

        public async Task<Student> GetStudent(Guid id)
        {
            return await _studentRepository.GetStudent(id);
        }

        public async Task<Student> AddStudent(Student student)
        {

            return await _studentRepository.CreateStudent(student);
        }

        public async Task<Student> UpdateStudent(Student student, Guid id)
        {
            return await _studentRepository.UpdateStudent(id, student);
        }
        public async Task<Student> DeleteStudent(Guid id)
        {
            return await _studentRepository.DeleteStudent(id);
        }

        public async Task<ICollection<CourseView>> GetEnrolledCources(Guid id)
        {
            return await _studentRepository.EnrolledCources(id);
        }

        public async Task<EnrollmentDto> EnrollCourses(EnrollmentDto enroll)
        {
            return await _studentRepository.EnrollForCourses(enroll);
        }
    }
}
