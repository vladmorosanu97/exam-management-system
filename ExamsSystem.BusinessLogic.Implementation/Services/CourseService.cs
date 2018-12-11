using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExamsSystem.BusinessLogic.Implementation.Mappers;
using ExamsSystem.BusinessLogic.Interfaces;
using ExamsSystem.BusinessLogic.Models;
using ExamsSystem.Data.Interfaces;

namespace ExamsSystem.BusinessLogic.Implementation.Services
{
    public class CourseService: ICourseService

    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
        public IEnumerable<CourseBlModel> GetCoursesByProfessorId(int professorId)
        {
            return _courseRepository.GetCoursesByProfessorId(professorId).Select(c => c.GetBlModel());
        }
    }
}
