using System.Collections.Generic;
using System.Linq;
using ExamsSystem.Data.Interfaces;
using ExamsSystem.Data.Models.Models;

namespace ExamsSystem.Data.Implementation
{
    public class CourseRepository: ICourseRepository
    {
        private readonly DatabaseContext _databaseContext;

        public CourseRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public IEnumerable<Course> GetCoursesByProfessorId(int professorId)
        {
            return _databaseContext.Courses.Where(c => c.ProfessorId == professorId);
        }
    }
}
