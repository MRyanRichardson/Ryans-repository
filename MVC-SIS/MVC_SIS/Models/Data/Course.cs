using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Exercises.Models.Data
{
    public class Course
    {
        public int CourseId { get; set; }
       
        public string CourseName { get; set; }
    }
}