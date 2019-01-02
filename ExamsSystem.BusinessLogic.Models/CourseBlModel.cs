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
        public IList<ProfessorCourseBlModel> ProfessorCourses { get; set; }
        public IList<StudentCourseBlModel> StudentCourses { get; set; }
        public ICollection<ExamBlModel> Exams { get; set; }
    }
}
