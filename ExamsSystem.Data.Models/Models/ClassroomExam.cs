using System;
using System.Collections.Generic;
using System.Text;

namespace ExamsSystem.Data.Models.Models
{
    public class ClassroomExam: BaseEntity
    {
        public int ClassroomId { get; set; }
        public Classroom Classroom { get; set; }

        public int ExamId { get; set; }
        public Exam Exam { get; set; }
    }
}
