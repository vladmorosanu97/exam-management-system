using System;
using System.Collections.Generic;
using System.Text;

namespace ExamsSystem.BusinessLogic.Models
{
    public class StudentBlModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public IList<StudentCourseBlModel> StudentCourses { get; set; }
    }
}
