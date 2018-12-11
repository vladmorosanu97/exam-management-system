using ExamsSystem.Data.Models.Models;

namespace ExamsSystem.Data.Interfaces
{
    public interface IExamRepository
    {
        void GetDataTest();
        Exam GetExamById(int id);
    }
}
