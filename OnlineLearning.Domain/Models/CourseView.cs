﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearning.Domain.Models
{
    public class CourseView
    {
        
        public Guid CourseId { get; set; }
        
        public string CourseName { get; set; }
      
        public string CourseCategory { get; set; }
        
        public int Balance { get; set; }
      
    }
}
