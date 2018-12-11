using ExamsSystem.BusinessLogic.Interfaces;
using ExamsSystem.Data.Interfaces;
using ExamsSystem.Data.Models.Models;

namespace ExamsSystem.BusinessLogic.Implementation.Services
{
    public class ExamService: IExamService
    {
        private readonly IExamRepository _examRepository;

        public ExamService(IExamRepository examRepository)
        {
            _examRepository = examRepository;
        }

        public void GetData()
        {
            _examRepository.GetDataTest();
        }

        public Exam GetExamById(int id)
        {
            return _examRepository.GetExamById(id);
        }
    }
}
