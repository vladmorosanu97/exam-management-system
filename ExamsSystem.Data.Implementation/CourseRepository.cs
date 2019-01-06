using System.Collections.Generic;
using System.Linq;
using ExamsSystem.Data.Interfaces;
using ExamsSystem.Data.Models.Models;
using Microsoft.EntityFrameworkCore;

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
            return _databaseContext.UserCourses.Include(pc => pc.Course).Where(pc => pc.UserId == professorId).Select(pc => pc.Course);
        }

        public Course GetCourseByProfessorIdAndCourseId(int professorId, int courseId)
        {
            return _databaseContext.UserCourses.Include(pc => pc.Course).Where(c => c.UserId == professorId && c.CourseId == courseId).Select(pc => pc.Course).FirstOrDefault();
        }

        public Course GetCourseById(int courseId)
        {
            return _databaseContext.Courses.FirstOrDefault(c => c.Id == courseId);
        }
    }
}
