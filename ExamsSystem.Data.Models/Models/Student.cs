using System;
using System.Collections.Generic;
using System.Text;

namespace ExamsSystem.Data.Models.Models
{
    public class Student: BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
//        public IEnumerable<Exam> Exams { get; set; }
//        public IEnumerable<Course> Courses { get; set; }
    }
}
