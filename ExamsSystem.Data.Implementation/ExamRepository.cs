using System;
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
            var items = _databaseContext.Courses.Include(c => c.StudentCourses).ThenInclude(c => c.Student).Where(c => c.Id == 2);
        }

        public Exam GetExamById(int professorId, int examId)
        {
            return _databaseContext.Exams.Include(e => e.Course).FirstOrDefault(e => e.Id == examId && e.ProfessorId == professorId);
        }

        public IEnumerable<Exam> GetExamsByProfessorId(int professorId)
        {
            return _databaseContext.Exams.Include(e => e.Course).Where(c => c.ProfessorId == professorId);
        }

        public void CreateExam(Exam exam)
        {
            _databaseContext.Exams.Add(exam);
            _databaseContext.SaveChanges();
        }

        public void EditExam(Exam exam)
        {
//            var item = _databaseContext.Exams.FirstOrDefault(e => e.Id == exam.Id);
//            item.Title = exam.Title;
//
//            _databaseContext.Exams.Update(item);
//            _databaseContext.SaveChanges();
        }
    }
}
