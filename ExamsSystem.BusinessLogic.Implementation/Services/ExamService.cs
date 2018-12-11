using ExamsSystem.BusinessLogic.Interfaces;
using ExamsSystem.Data.Implementation;
using ExamsSystem.Data.Interfaces;

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
    }
}
