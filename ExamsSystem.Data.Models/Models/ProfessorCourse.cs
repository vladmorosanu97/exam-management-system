using System;
using System.Collections.Generic;
using System.Text;

namespace ExamsSystem.Data.Models.Models
{
    public class ProfessorCourse: BaseEntity
    {
        public int ProfessorId { get; set; }
        public Professor Professor { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
