using System;
using System.Linq;
using ExamsSystem.Data.Implementation;
using ExamsSystem.Data.Interfaces;
using ExamsSystem.Data.Models.Models;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExamSystem.Tests
{
    [TestClass]
    public class CourseRepositoryTest
    {
        private DatabaseContext _databaseContext;
        private ICourseRepository _courseRepository;
        private DbContextOptions<DatabaseContext> _options;
        public Course course { get; set; }
        public Professor professor { get; set; }

        [TestInitialize]
        public void InitTests()
        {
            _options = new DbContextOptionsBuilder<DatabaseContext>().UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ExamSystem;Trusted_Connection=True;").Options;

            _databaseContext = new DatabaseContext(_options);
            _courseRepository = new CourseRepository(_databaseContext);

            professor = InitProfessor();
;
            _databaseContext.Professors.Add(professor);
            _databaseContext.SaveChanges();

            var id = professor.Id;

            course = InitCourse();
            course.ProfessorId = professor.Id;

            _databaseContext.Courses.Add(course);
            _databaseContext.SaveChanges();
        }

        public Professor InitProfessor()
        {
            return new Professor()
            {
                Email = "profesor@email.com",
                Name = "Professor",
                Password = "secret"
            };
        }

        public Course InitCourse()
        {
            return new Course()
            {
                Description = "ceva greu",
                Title = "PLP",
            };
        }
        [TestMethod]
        public void GivenProfessorId_WhenCallGetCoursesByProfessorId_ThenShouldReturnAllCoursesThatHaveProfessorId()
        {
            //arrange
            var professorId = professor.Id;

            //act
            var items = _courseRepository.GetCoursesByProfessorId(professorId);

            //assert
            foreach (var course in items)
            {
                course.ProfessorId.Should().Be(professorId);
            }
        }

        [TestMethod]
        public void GivenInvalidProfessorId_WhenCallGetCoursesByProfessorId_ThenShouldNull()
        {
            //arrange
            var professorId = -1;

            //act
            var items = _courseRepository.GetCoursesByProfessorId(professorId);

            //assert
            items.Count().Should().Be(0);
        }

        [TestMethod]
        public void GivenProfessorIdAndCourseId_WhenCallGetCoursesByProfessorIdAndCourseId_ThenShouldReturnTheCorrectCourse()
        {
            //arrange
            var professorId = professor.Id;
            var courseId = course.Id;

            //act
            var expectedCourse = _courseRepository.GetCourseByProfessorIdAndCourseId(professorId, courseId);

            //assert
            expectedCourse.ProfessorId.Should().Be(professorId);
            expectedCourse.Id.Should().Be(courseId);
        }

        [TestMethod]
        public void GivenInvalidProfessorIdAndCourseId_WhenCallGetCoursesByProfessorIdAndCourseId_ThenShouldReturnNull()
        {
            //arrange
            var professorId = -1;
            var courseId = course.Id;

            //act
            var expectedCourse = _courseRepository.GetCourseByProfessorIdAndCourseId(professorId, courseId);

            //assert
            expectedCourse.Should().BeNull();
        }

        [TestMethod]
        public void GivenProfessorIdAndInvalidCourseId_WhenCallGetCoursesByProfessorIdAndCourseId_ThenShouldReturnNull()
        {
            //arrange
            var professorId = professor.Id;
            var courseId = -1;

            //act
            var expectedCourse = _courseRepository.GetCourseByProfessorIdAndCourseId(professorId, courseId);

            //assert
            expectedCourse.Should().BeNull();
        }

        [TestMethod]
        public void GivenInvalidProfessorIdAndInvalidCourseId_WhenCallGetCoursesByProfessorIdAndCourseId_ThenShouldReturnNull()
        {
            //arrange
            var professorId = -1;
            var courseId = -1;

            //act
            var expectedCourse = _courseRepository.GetCourseByProfessorIdAndCourseId(professorId, courseId);

            //assert
            expectedCourse.Should().BeNull();
        }

        [TestCleanup]
        public void CleanUp()
        {
            _databaseContext.Courses.Remove(course);
            _databaseContext.Professors.Remove(professor);
            _databaseContext.SaveChanges();
        }
    }
}
