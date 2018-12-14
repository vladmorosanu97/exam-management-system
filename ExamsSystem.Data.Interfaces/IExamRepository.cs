using ExamsSystem.Data.Models.Models;
using System.Collections.Generic;

namespace ExamsSystem.Data.Interfaces
{
    public interface IExamRepository
    {
        void GetDataTest();
        Exam GetExamById(int professorId, int examId);
        IEnumerable<Exam> GetExamsByProfessorId(int professorId);
        void CreateExam(Exam exam);
    }
}
