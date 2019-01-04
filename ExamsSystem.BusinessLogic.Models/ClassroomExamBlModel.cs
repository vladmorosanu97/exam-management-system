using System;
using System.Collections.Generic;
using System.Text;

namespace ExamsSystem.BusinessLogic.Models
{
    public class ClassroomExamBlModel
    {
        public int ClassroomId { get; set; }
        public ClassroomBlModel Classroom { get; set; }
        public int ExamId { get; set; }
        public ExamBlModel Exam { get; set; }
    }
}
