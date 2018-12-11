using System;
using System.Collections.Generic;
using System.Text;

namespace ExamsSystem.BusinessLogic.Models
{
    public class StudentCourseBlModel
    {
        public int StudentId { get; set; }
        public StudentBlModel Student { get; set; }

        public int CourseId { get; set; }
        public CourseBlModel Course { get; set; }
    }
}
