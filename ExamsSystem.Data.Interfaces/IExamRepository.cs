using ExamsSystem.Data.Models.Models;
using System.Collections.Generic;

namespace ExamsSystem.Data.Interfaces
{
    public interface IExamRepository
    {
        void GetDataTest();
        Exam GetExamById(int professorId, int examId);
        IEnumerable<Exam> GetExamsByProfessorId(int professorId);
        int CreateExam(Exam exam);
        void EditExam(Exam exam);
        IEnumerable<Exam> GetExamsByStudentId(int studentId);
    }
}
