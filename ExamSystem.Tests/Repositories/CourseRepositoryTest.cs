using ExamsSystem.Data.Implementation;
using ExamsSystem.Data.Interfaces;
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
        [TestInitialize]
        public void InitTests()
        {
            _options = new DbContextOptionsBuilder<DatabaseContext>().UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ExamSystem;Trusted_Connection=True;").Options;

            _databaseContext = new DatabaseContext(_options);
            _courseRepository = new CourseRepository(_databaseContext);
        }


        [TestMethod]
        public void GivenProfessorId_WhenCallGetCoursesByProfessorId_ThenShouldReturnAllCoursesThatHaveProfessorId()
        {
            //arrange
            var professorId = 1;

            //act
            var items = _courseRepository.GetCoursesByProfessorId(professorId);

            //assert
            foreach (var course in items)
            {
                course.ProfessorId.Should().Be(professorId);
            }
        }
    }
}
