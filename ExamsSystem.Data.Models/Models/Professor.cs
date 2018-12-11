using System;
using System.Collections.Generic;
using System.Text;

namespace ExamsSystem.Data.Models.Models
{
    public class Professor: BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<Exam> Exams { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
