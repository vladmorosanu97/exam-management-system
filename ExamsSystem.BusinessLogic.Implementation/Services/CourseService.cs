﻿using System.Collections.Generic;
using System.Linq;
using ExamsSystem.BusinessLogic.Implementation.Mappers;
using ExamsSystem.BusinessLogic.Interfaces;
using ExamsSystem.BusinessLogic.Models;
using ExamsSystem.Data.Interfaces;

namespace ExamsSystem.BusinessLogic.Implementation.Services
{
    public class CourseService : ICourseService

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

        public CourseBlModel GetCourseByProfessorIdAndCourseId(int professorId, int courseId)
        {
            return _courseRepository.GetCourseByProfessorIdAndCourseId(professorId, courseId).GetBlModel();
        }

        public IEnumerable<CourseBlModel> GetCourses()
        {
            return _courseRepository.GetCourses().Select(c => c.GetBlModel()).ToList();
        }
    }
}
