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
            var items = _databaseContext.Professors.Include(a => a.Courses).ThenInclude(c => c.Exams).Where(a => a.Id == 1);
        }

        public Exam GetExamById(int professorId,int examId)
        {
            return _databaseContext.Exams.Include(e => e.Course).FirstOrDefault(e => e.Id == examId && e.Course.ProfessorId == professorId);
        }

        public IEnumerable<Exam> GetExamsByProfessorId(int professorId)
        {
            return _databaseContext.Exams.Include(e => e.Course).Where(c => c.Course.ProfessorId == professorId);
        }

        public void CreateExam(Exam exam)
        {
            _databaseContext.Exams.Add(exam);
            _databaseContext.SaveChanges();
        }

    }
}
