﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ExamsSystem.BusinessLogic.Models
{
    public class CourseBlModel
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public int ProfessorId { get; set; }
        public ProfessorBlMode Professor { get; set; }
        public IList<StudentCourseBlModel> StudentCourses { get; set; }
        public ICollection<ExamBlModel> Exams { get; set; }
    }
}