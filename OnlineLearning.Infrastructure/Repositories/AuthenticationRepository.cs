using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineLearning.Application.Dtos;
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
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly AppDbContext _context;
        private readonly PasswordHasher<User> _passwordHasher;
        public AuthenticationRepository(AppDbContext context) 
        { 
            _context = context;  
            _passwordHasher = new PasswordHasher<User>();
        }
        public async Task<User> UserRegister(User user)
        {
            var _user = _context.Users.FirstOrDefault(u => u.Email == user.Email);
            if (_user == null)
            {
                //var useradd = new User()
                //{
                //    Email = user.Email,
                //    Role = user.Role,
                //};
                user.Password = _passwordHasher.HashPassword(user, user.Password);
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                return user;
            }
            return null;
        }

        public async Task<User> AuthenticateUserAsync(UserLogin userdto)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Email == userdto.Email);
            if (user != null)
            {
                var verificationResult = _passwordHasher.VerifyHashedPassword(user, user.Password, userdto.Password);
                if (verificationResult == PasswordVerificationResult.Success)
                {
                    return user;
                }
            }
            return null;
        }
        //public async Task<string> UserLogin(UserLogin login)
        //{

        //    return "token";
        //}
    }
}
