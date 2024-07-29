using OnlineLearning.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearning.Application.Dtos
{
    public class LoginResponce
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        //public string Password { get; set; }

        public SystemRole Role { get; set; }
        public string token { get; set; }
    }
}
