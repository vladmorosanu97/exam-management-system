using ExamsSystem.BusinessLogic.Implementation.Mappers;
using ExamsSystem.BusinessLogic.Interfaces;
using ExamsSystem.BusinessLogic.Models;
using ExamsSystem.Data.Interfaces;
using ExamsSystem.Data.Models.Models;
using System.Collections.Generic;
using System.Linq;

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

        public ExamBlModel GetExamById(int professorId, int examId)
        {
            return _examRepository.GetExamById(professorId, examId).GetExamBlModel();
        }

        public IEnumerable<ExamBlModel> GetExamsByProfessorId(int professorId)
        {
            return _examRepository.GetExamsByProfessorId(professorId).Select(c => c.GetExamBlModel());
        }
    }
}
