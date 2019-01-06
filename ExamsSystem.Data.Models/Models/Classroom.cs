using System;
using System.Collections.Generic;
using System.Text;

namespace ExamsSystem.Data.Models.Models
{
    public class Classroom: BaseEntity
    {
        public string Name { get; set; }

        public List<ClassroomExam> ClassroomExams { get; set; }
    }
}
