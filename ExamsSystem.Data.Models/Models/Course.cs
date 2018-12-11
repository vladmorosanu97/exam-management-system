using System;
using System.Collections.Generic;
using System.Text;

namespace ExamsSystem.Data.Models.Models
{
    public class Course: BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public int ProfessorId { get; set; }
        public Professor Professor { get; set; }
        public IList<StudentCourse> StudentCourses { get; set; }
        public ICollection<Exam> Exams { get; set; }
    }
}
