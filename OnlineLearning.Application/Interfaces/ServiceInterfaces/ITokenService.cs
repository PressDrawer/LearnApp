using OnlineLearning.Application.Dtos;
using OnlineLearning.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearning.Application.Interfaces.ServiceInterfaces
{
    public interface ITokenService
    {
        string GenerateToken(UserDto user);
    }
}
