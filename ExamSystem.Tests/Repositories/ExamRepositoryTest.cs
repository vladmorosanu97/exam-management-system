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

            var id = professor.Id;

            exam = InitExam();
            exam.ProfessorId = professor.Id;

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
                Title = "PLP",

            };
        }
        [TestMethod]
        public void GivenExamId_WhenCallGetExamsByProfessorId()
        {
            //arrange
            var professorId = professor.Id;

            //act
            var items = _examRepository.GetExamsByProfessorId(professorId);

            //assert

            foreach (var exam in items)
            {
                exam.ProfessorId.Should().Be(professorId);
            }

        }
        
        [TestCleanup]
        public void CleanUp()
        {
            _databaseContext.Exams.Remove(exam);
           
            _databaseContext.SaveChanges();
        }
    }
}
