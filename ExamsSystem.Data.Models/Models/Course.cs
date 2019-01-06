using System;
using System.Collections.Generic;
using System.Text;

namespace ExamsSystem.Data.Models.Models
{
    public class Course: BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<UserCourse> UserCourses { get; set; }
        public List<Exam> Exams { get; set; }
    }
}
