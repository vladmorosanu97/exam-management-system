﻿using System;
using System.Collections.Generic;
using System.Linq;
using ExamsSystem.Data.Interfaces;
using ExamsSystem.Data.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamsSystem.Data.Implementation
{
    public class ExamRepository: IExamRepository
    {
        private readonly DatabaseContext _databaseContext;

        public ExamRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void GetDataTest()
        {
//            var items = _databaseContext.Courses.Include(c => c.StudentCourses).ThenInclude(c => c.Student).Where(c => c.Id == 2);
        }

        public Exam GetExamById(int examId)
        {
            return _databaseContext.Exams.Include(e => e.Course).FirstOrDefault(e => e.Id == examId);
        }

        public IEnumerable<Exam> GetExamsByProfessorId(int professorId)
        {
            return _databaseContext.Exams.Include(e => e.Course)
                .Include(e => e.ClassroomExams)
                .Where(c => c.Course.UserCourses.Select(e => e.UserId).FirstOrDefault() == professorId);
        }

        public int CreateExam(Exam exam)
        {
            _databaseContext.Exams.Add(exam);
            _databaseContext.SaveChanges();
            return exam.Id;
        }

        public void EditExam(Exam exam)
        {
            var item = _databaseContext.Exams.FirstOrDefault(e => e.Id == exam.Id);
            item.Title = exam.Title;
            item.ClassroomExams = exam.ClassroomExams;

            item.CourseId = exam.CourseId;
            _databaseContext.Exams.Update(item);
            _databaseContext.SaveChanges();
        }

        public IEnumerable<Exam> GetExamsByStudentId(int studentId)
        {
//            return _databaseContext.Exams.Include(e => e.Course)
//                .Include(e => e.ClassroomExams)
//                .Where(c => c.UserId == studentId);
               return new List<Exam>();
        }

        public void MarkPresentAtExams(int userId, int examId)
        {
            _databaseContext.Add(new UserExam(userId, examId));
            _databaseContext.SaveChanges();
        }
    }
}
