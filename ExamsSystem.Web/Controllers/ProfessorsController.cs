using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices.ComTypes;
using ExamsSystem.BusinessLogic.Interfaces;
using ExamsSystem.BusinessLogic.Models;
using ExamsSystem.Data.Models.Models;
using ExamsSystem.Web.Mappers;
using ExamsSystem.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExamsSystem.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorsController : ControllerBase
    {
        private readonly IExamService _examService;
        private readonly ICourseService _courseService;
        private readonly IClassroomService _classroomService;

        public ProfessorsController(IExamService examService,
            ICourseService courseService,
            IClassroomService classroomService)
        {
            _examService = examService;
            _courseService = courseService;
            _classroomService = classroomService;
        }


        [HttpGet("index")]
        public IActionResult Index()
        {
            _examService.GetData();
            return Ok();
        }

        [HttpGet("{professorId:int}/courses")]
        public IActionResult GetCoursesByProfessorId(int professorId)
        {
            try
            {
                return Ok(_courseService.GetCoursesByProfessorId(professorId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{professorId:int}/courses/{courseId:int}")]
        public IActionResult GetCoursesByProfessorIdAndCourseId(int professorId, int courseId)
        {
            try
            {
                return Ok(_courseService.GetCourseByProfessorIdAndCourseId(professorId, courseId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{professorId:int}/exams/{examId:int}")]
        public IActionResult GetExamById(int professorId, int examId)
        {
            try
            {
                return Ok(_examService.GetExamById(professorId, examId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{professorId:int}/exams")]
        public IActionResult GetExamsByProfessorId(int professorId)
        {
            try
            {
                return Ok(_examService.GetExamsByProfessorId(professorId));
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPost("{professorId:int}/exams")]
        public IActionResult CreateExam([FromBody] ExamViewModel exam)
        {
           

            var examBlModel = exam.GetBlModel();

            _examService.CreateExam(examBlModel, exam.Classrooms);
            return NoContent();
        }

        [HttpPut("{professorId:int}/exams")]
        public IActionResult EditExam([FromBody] ExamViewModel exam)
        {
            var result = _examService.GetExamById(exam.ProfessorId, exam.Id);

            if (result == null)
            {
                return BadRequest("Invalid exam");
            }

            _examService.EditExam(exam.GetBlModel(), exam.Classrooms);
            return NoContent();
        }
    }
}
