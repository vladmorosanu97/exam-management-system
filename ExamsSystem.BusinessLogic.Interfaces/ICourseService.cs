using System.Collections.Generic;
using ExamsSystem.BusinessLogic.Models;

namespace ExamsSystem.BusinessLogic.Interfaces
{
    public interface ICourseService
    {
        IEnumerable<CourseBlModel> GetCoursesByProfessorId(int professorId);
    }
}
