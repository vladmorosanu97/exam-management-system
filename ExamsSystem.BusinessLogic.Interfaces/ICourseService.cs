using System;
using System.Collections.Generic;
using System.Text;
using ExamsSystem.BusinessLogic.Models;

namespace ExamsSystem.BusinessLogic.Interfaces
{
    public interface ICourseService
    {
        IEnumerable<CourseBlModel> GetCoursesByProfessorId(int professorId);
    }
}
