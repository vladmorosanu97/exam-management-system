using System;
using System.Collections.Generic;
using System.Text;

namespace ExamsSystem.BusinessLogic.Models
{
    public class CourseBlModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<UserCourseBlModel> UserCourses { get; set; }
        public List<ExamBlModel> Exams { get; set; }
    }
}
