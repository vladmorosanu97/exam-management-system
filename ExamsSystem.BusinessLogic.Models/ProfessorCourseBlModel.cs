using System;
using System.Collections.Generic;
using System.Text;

namespace ExamsSystem.BusinessLogic.Models
{
    public class ProfessorCourseBlModel
    {
        public int Id { get; set; }
        public int ProfessorId { get; set; }
        public ProfessorBlMode Professor { get; set; }

        public int CourseId { get; set; }
        public CourseBlModel Course { get; set; }
    }
}
