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
        void CreateExam(ExamBlModel exam, List<int> classrooms);
        void EditExam(ExamBlModel exam, List<int> classrooms);
        IEnumerable<ExamBlModel> GetExamsByStudentId(int studentId);
    }
}
