using System;
using System.Collections.Generic;
using System.Text;

namespace ExamsSystem.BusinessLogic.Models
{
    public class ExamBlModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? StartHour { get; set; }
        public DateTime? FinishHour { get; set; }
        public int CourseId { get; set; }
        public CourseBlModel Course { get; set; }

        public int ProfessorId { get; set; }
        public UserBlModel User { get; set; }
        public IList<ClassroomExamBlModel> ClassroomExams { get; set; }
    }
}
