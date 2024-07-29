using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearning.Application.Dtos
{
    public class CourseDto
    {
        //[Required]
        public string CourseName { get; set; }
        
        public string CourseCategory { get; set; }
        
        public int CourseFee { get; set; }

        
    }
}
