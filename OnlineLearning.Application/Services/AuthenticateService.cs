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
    public class AuthenticateService : IAuthenticateService
    {
        private readonly IAuthenticationRepository _authRepo;
        private readonly ITokenService _tokenService;   
        public AuthenticateService(IAuthenticationRepository authRepo,ITokenService tokenService) 
        {
            _authRepo= authRepo;
            _tokenService= tokenService;        
           
        }
        async Task<User> IAuthenticateService.RegisterUser(User user)
        {
            return await _authRepo.UserRegister(user);
            
        }
        public async Task<LoginResponce> UserLogin(UserLogin login)
        {
            var user = await _authRepo.AuthenticateUserAsync(login);
            var _user = new UserDto()
            {
                Email = user.Email,
                Password = user.Password,
                Role = user.Role
            };
            if(user != null)
            {
                var token = _tokenService.GenerateToken(_user);
                var loginResponce = new LoginResponce()
                {
                    Id=user.UserId,
                    Email = user.Email,
                    Role = user.Role,
                    token = token

                };
                return loginResponce;
            }
            return null;    
        }

        
    }
}
