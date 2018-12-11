using ExamsSystem.Data.Models.Models;

namespace ExamsSystem.BusinessLogic.Interfaces
{
    public interface IExamService
    {
        void GetData();
        Exam GetExamById(int id);
    }
}
