using ExamsSystem.BusinessLogic.Models;
using ExamsSystem.Data.Models.Models;
using System.Collections.Generic;

namespace ExamsSystem.BusinessLogic.Interfaces
{
    public interface IExamService
    {
        void GetData();
        ExamBlModel GetExamById(int professorId, int id);
        IEnumerable<ExamBlModel> GetExamsByProfessorId(int professorId);
        void CreateExam(Exam exam);
    }
}
