using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamsSystem.Data.Identity.Models;
using ExamsSystem.Data.Implementation;
using ExamsSystem.Data.Interfaces;
using ExamsSystem.Data.Models.Models;
using ExamsSystem.Web.Models;
using ExamSystem.Tests.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExamSystem.Tests
{
    [TestClass]
    public class ExamRepositoryTest
    {
        private DatabaseContext _databaseContext;
        private ICourseRepository _courseRepository;
        private IExamRepository _examRepository;
        public Exam _exam { get; set; }
        private User _professor;
        private User _student;
        private Classroom _classroom;
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
        private UserRegisterViewModel InitStudent()
        {
            return new UserRegisterViewModel()
            {
                Email = "adelin@gmail.com",
                FirstName = "Adelin",
                LastName = "Pamint",
                Password = "Parola123"
            };
        }

        private Classroom InitClassroom()
        {
            return new Classroom()
            {
                Name = "C112"
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

            userViewModel = InitStudent();
            result = await _userManagerTest.CreateAsync(new User
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

            _student = await _userManagerTest.FindByEmailAsync(userViewModel.Email);

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

            _classroom = InitClassroom();
            _databaseContext.Classrooms.Add(_classroom);
            _databaseContext.SaveChanges();
            
            _examRepository = new ExamRepository(_databaseContext);


            _exam = InitExam();
            _exam.CourseId = _course.Id;

            _databaseContext.Exams.Add(_exam);
            _databaseContext.SaveChanges();

            var studentExam = new UserExam()
            {
                UserId = _student.Id,
                ExamId = _exam.Id
            };
            _databaseContext.UserExams.Add(studentExam);

            return "Success";
        }

        [TestInitialize]
        public void InitTests()
        {
            List<Task> tasks = new List<Task> { InitializeTests() };
            Task.WaitAll(tasks.ToArray());
        }

        public Exam InitExam()
        {
            return new Exam()
            {
                Description = "ceva greu",
                Title = "Partial",
                CourseId = _course.Id

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
            var professorId = _professor.Id;

            //act
            var items = _examRepository.GetExamsByProfessorId(professorId);

            //assert

            items.FirstOrDefault()?.Course.UserCourses.Select(e => e.UserId == professorId).Should().NotBeNull();
            
        }

        [TestMethod]
        public void GivenExamId_WhenCallingGetExamByIdWithValidProfessorIdAndValidExamId_ThenShouldReturnTheCorrectExam()
        {
            // arrange
            var professorId = _professor.Id;
            var examId = _exam.Id;

            // act
            var actualResult = _examRepository.GetExamById(examId);

            // assert
            actualResult.Id.Should().Be(examId);
        }

        [TestMethod]
        public void GivenExamId_WhenCallingGetExamByIdWithInvalidProfessorIdAndValidExamId_ThenShouldReturnNull()
        {
            // arrange
            var examId = -1;

            // act
            var actualResult = _examRepository.GetExamById(examId);

            // assert
            actualResult.Should().BeNull();
        }

        [TestMethod]
        public void GivenExamId_WhenCallingGetExamByIdWithValidProfessorIdAndInvalidExamId_ThenShouldReturnNull()
        {
            // arrange
            var professorId = _professor.Id;
            var examId = -1;

            // act
            var actualResult = _examRepository.GetExamById(examId);

            // assert
            actualResult.Should().BeNull();
        }

        [TestMethod]
        public void GivenExamId_WhenCallingGetExamByIdWithInvalidProfessorIdAndInvalidExamId_ThenShouldReturnNull()
        {
            // arrange
            var examId = -1;

            // act
            var actualResult = _examRepository.GetExamById(examId);

            // assert
            actualResult.Should().BeNull();
        }


        [TestMethod]
        public void GivenExamViewModel_WhenCallingCreateExam_ThenShouldCreateANewExamWithClassrooms()
        {
            // arrange
            var newExam = new Exam()
            {
                CourseId = _course.Id,
                Title = "New Exam",
                ClassroomExams = new List<ClassroomExam>
                {
                    new ClassroomExam()
                    {
                        ClassroomId = _classroom.Id,
                        ExamId = _exam.Id
                    }
                }
            };
            var expected = _databaseContext.Exams.Count() + 1;


            // act
            _examRepository.CreateExam(newExam);
            var result = _databaseContext.Exams.Count();
            // assert
            expected.Should().Be(result);
        }

        [TestMethod]
        public void GivenExamViewModel_WhenCallingUpdateExam_ThenShouldUpdateExistingExam()
        {
            // arrange
            var exam = _examRepository.GetExamById(_exam.Id);
            exam.Title = "Test";
            // act
            _examRepository.EditExam(exam);
            var result = _examRepository.GetExamById( _exam.Id);
            // assert
            exam.Title.Should().Be(result.Title);
        }

        [TestMethod]
        public void GivenValidStudentId_WhenCallingGetExamsByStudentId_ThenShouldReturnAllExamsOfStudent()
        {
            //arrange
            var studentId = _student.Id;
            //act
            var items = _examRepository.GetExamsByStudentId(studentId);

            //assert
            items.FirstOrDefault()?.Course.UserCourses.Select(e => e.UserId == studentId).Should().NotBeNull();
        }

        [TestMethod]
        public void GivenInvalidStudentId_WhenCallingGetExamsByStudentId_ThenShouldReturnNull()
        {
            //arrange
            var studentId = -1;
            //act
            var items = _examRepository.GetExamsByStudentId(studentId);
            //assert
            items.Should().BeNull();
        }

        [TestCleanup]
        public void CleanUp()
        {
            _databaseContext.Exams.Remove(_exam);
            _databaseContext.Courses.Remove(_course);
            _databaseContext.Classrooms.Remove(_classroom);
            _databaseContext.SaveChanges();
            _userManagerTest.DeleteAsync(_student);
            _userManagerTest.DeleteAsync(_professor);
        }
    }
}
