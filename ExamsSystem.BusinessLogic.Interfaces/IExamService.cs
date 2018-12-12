using ExamsSystem.BusinessLogic.Models;
using ExamsSystem.Data.Models.Models;
using System.Collections.Generic;

namespace ExamsSystem.BusinessLogic.Interfaces
{
    public interface IExamService
    {
        void GetData();
        Exam GetExamById(int id);
        IEnumerable<ExamBlModel> GetExamsByProfessorId(int professorId);
    }
}
