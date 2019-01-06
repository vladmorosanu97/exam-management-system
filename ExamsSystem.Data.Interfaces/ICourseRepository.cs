using System.Collections.Generic;
using ExamsSystem.Data.Models.Models;

namespace ExamsSystem.Data.Interfaces
{
    public interface ICourseRepository
    {
        IEnumerable<Course> GetCoursesByProfessorId(int professorId);
        Course GetCourseByProfessorIdAndCourseId(int professorId, int courseId);
        Course GetCourseById(int courseId);
    }
}
