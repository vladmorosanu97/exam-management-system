﻿using System;
using System.Collections.Generic;

namespace ExamsSystem.Data.Models.Models
{
    public class Exam: BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? StartHour { get; set; }
        public DateTime? FinishHour { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public ICollection<ClassroomExam> ClassroomExams { get; set; }
        public int ProfessorId { get; set; }
        public Professor  Professor { get; set; }
    }
}
