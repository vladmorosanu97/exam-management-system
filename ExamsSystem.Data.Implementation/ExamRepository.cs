using System.Linq;
using ExamsSystem.Data.Interfaces;
using ExamsSystem.Data.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamsSystem.Data.Implementation
{
    public class ExamRepository: IExamRepository
    {
        private readonly DatabaseContext _databaseContext;

        public ExamRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void GetDataTest()
        {
            var items = _databaseContext.Professors.Include(a => a.Courses).ThenInclude(c => c.Exams).Where(a => a.Id == 1);
        }

        public Exam GetExamById(int id)
        {
            return _databaseContext.Exams.Find(id);
        }
    }
}
