using System;
using ExamsSystem.Data.Implementation;
using ExamsSystem.Data.Interfaces;
using ExamsSystem.Data.Models.Models;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExamSystem.Tests
{
    [TestClass]
    public class ExamRepositoryTest
    {
        private DatabaseContext _databaseContext;
        private IExamRepository _examRepository;
        private ICourseRepository _courseRepository;
        private DbContextOptions<DatabaseContext> _options;
        public Exam exam { get; set; }
        public Course course { get; set; }
        public Professor professor { get; set; }
        [TestInitialize]
        public void InitTests()
        {
            _options = new DbContextOptionsBuilder<DatabaseContext>().UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ExamSystem;Trusted_Connection=True;").Options;

            _databaseContext = new DatabaseContext(_options);
            _courseRepository = new CourseRepository(_databaseContext);
            _examRepository = new ExamRepository(_databaseContext);
            professor = InitProfessor();
            

            _databaseContext.Professors.Add(professor);
            _databaseContext.SaveChanges();

            course = InitCourse();
            course.ProfessorId = professor.Id;

            _databaseContext.Courses.Add(course);
            _databaseContext.SaveChanges();

            exam = InitExam();
            exam.CourseId = course.Id;

            _databaseContext.Exams.Add(exam);
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

        public Exam InitExam()
        {
            return new Exam()
            {
                Description = "ceva greu",
                Title = "Partial",

            };
        }

        public Course InitCourse()
        {
            return new Course()
            {
                Description = "ceva greu",
                Title = "ML",

            };
        }

        [TestMethod]
        public void GivenExamId_WhenCallGetExamsByProfessorId_ShouldReturnCorrectExamsForCoursesThatHaveProfessorId()
        {
            //arrange
            var professorId = professor.Id;

            //act
            var items = _examRepository.GetExamsByProfessorId(professorId);

            //assert
            foreach (var exam in items)
            {
                exam.Course.ProfessorId.Should().Be(professorId);
            }
        }

        [TestMethod]
        public void GivenExamId_WhenCallingGetExamByIdWithValidProfessorIdAndValidExamId_ThenShouldReturnTheCorrectExam()
        {
            // arrange
            var professorId = professor.Id;
            var examId = exam.Id;

            // act
            var actualResult = _examRepository.GetExamById(professorId, examId);

            // assert
            actualResult.Id.Should().Be(examId);
            actualResult.Course.ProfessorId.Should().Be(professorId);
        }

        [TestMethod]
        public void GivenExamId_WhenCallingGetExamByIdWithInvalidProfessorIdAndValidExamId_ThenShouldReturnNull()
        {
            // arrange
            var professorId = -1;
            var examId = exam.Id;

            // act
            var actualResult = _examRepository.GetExamById(professorId, examId);

            // assert
            actualResult.Should().BeNull();
        }

        [TestMethod]
        public void GivenExamId_WhenCallingGetExamByIdWithValidProfessorIdAndInvalidExamId_ThenShouldReturnNull()
        {
            // arrange
            var professorId = professor.Id;
            var examId = -1;

            // act
            var actualResult = _examRepository.GetExamById(professorId, examId);

            // assert
            actualResult.Should().BeNull();
        }

        [TestMethod]
        public void GivenExamId_WhenCallingGetExamByIdWithInvalidProfessorIdAndInvalidExamId_ThenShouldReturnNull()
        {
            // arrange
            var professorId = -1;
            var examId = -1;

            // act
            var actualResult = _examRepository.GetExamById(professorId, examId);

            // assert
            actualResult.Should().BeNull();
        }

        [TestCleanup]
        public void CleanUp()
        {
            _databaseContext.Exams.Remove(exam);
            _databaseContext.Courses.Remove(course);
            _databaseContext.Professors.Remove(professor);
            _databaseContext.SaveChanges();
        }
    }
}
