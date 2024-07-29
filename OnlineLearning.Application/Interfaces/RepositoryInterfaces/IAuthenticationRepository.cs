using OnlineLearning.Application.Dtos;
using OnlineLearning.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearning.Application.Interfaces.RepositoryInterfaces
{
    public interface IAuthenticationRepository
    {
        public Task<User> UserRegister(User user);
        public Task<User> AuthenticateUserAsync(UserLogin userdto);
        //public string UserLogin(UserLogin user);            
    }
}
