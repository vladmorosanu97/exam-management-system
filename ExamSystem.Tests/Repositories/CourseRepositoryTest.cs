using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamsSystem.Data.Identity.Models;
using ExamsSystem.Data.Implementation;
using ExamsSystem.Data.Interfaces;
using ExamsSystem.Data.Models.Models;
using ExamSystem.Tests.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExamSystem.Tests
{
    [TestClass]
    public class CourseRepositoryTest
    {
        private DatabaseContext _databaseContext;
        private ICourseRepository _courseRepository;
        private User _professor;
        private Course _course;
        private UserManager<User> _userManagerTest;

        private UserRegisterViewModel InitProfessor()
        {
            return new UserRegisterViewModel()
            {
                Email = "vlad",
                FirstName = "vlad",
                LastName = "Vlad",
                Password = "Steaua123"
            };
        }
        private async Task<string> InitializeTests()
        {
            _databaseContext = DatabaseContextGenerator.GenerateDbContext();
            _databaseContext.Database.EnsureCreated();
            _userManagerTest = UserManagerGenerator.GenerateUserManager();

            var userViewModel = InitProfessor();
            var result = await _userManagerTest.CreateAsync(new User
            {
                Email = userViewModel.Email.ToLower(),
                UserName = userViewModel.Email.ToLower(),
                FirstName = userViewModel.FirstName,
                LastName = userViewModel.LastName
            }, userViewModel.Password);

            if (!result.Succeeded)
            {
                throw new System.Exception("Operation error");
            }

            _professor = await _userManagerTest.FindByEmailAsync(userViewModel.Email);

            _courseRepository = new CourseRepository(_databaseContext);

            _course = InitCourse();
            _databaseContext.Courses.Add(_course);
            _databaseContext.SaveChanges();


            var professorCourse = new UserCourse
            {
                UserId = _professor.Id,
                CourseId = _course.Id
            };
            _databaseContext.UserCourses.Add(professorCourse);
            _databaseContext.SaveChanges();
            return "Success";
        }

        [TestInitialize]
        public void InitTests()
        {

            List<Task> tasks = new List<Task> { InitializeTests() };
            Task.WaitAll(tasks.ToArray());

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
            var professorId = _professor.Id;

            //act
            var items = _courseRepository.GetCoursesByProfessorId(professorId);

            //assert
            items.FirstOrDefault()?.UserCourses.Select(e => e.UserId).FirstOrDefault().Should().Be(professorId);
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
            var professorId = _professor.Id;
            var courseId = _course.Id;

            //act
            var expectedCourse = _courseRepository.GetCourseByProfessorIdAndCourseId(professorId, courseId);

            //assert
            expectedCourse.UserCourses.Where(e => e.UserId == professorId).Select(e => e.UserId).Should().BeEquivalentTo(professorId);
            expectedCourse.Id.Should().Be(courseId);
        }

        [TestMethod]
        public void GivenInvalidProfessorIdAndCourseId_WhenCallGetCoursesByProfessorIdAndCourseId_ThenShouldReturnNull()
        {
            //arrange
            var professorId = -1;
            var courseId = _course.Id;

            //act
            var expectedCourse = _courseRepository.GetCourseByProfessorIdAndCourseId(professorId, courseId);

            //assert
            expectedCourse.Should().BeNull();
        }

        [TestMethod]
        public void GivenProfessorIdAndInvalidCourseId_WhenCallGetCoursesByProfessorIdAndCourseId_ThenShouldReturnNull()
        {
            //arrange
            var professorId = _professor.Id;
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
            _databaseContext.Courses.Remove(_course);
            _databaseContext.SaveChanges();

            _userManagerTest.DeleteAsync(_professor);
        }
    }
}


