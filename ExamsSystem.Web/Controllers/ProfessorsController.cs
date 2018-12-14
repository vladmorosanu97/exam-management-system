using System;
using System.Net;
using System.Net.Http;
using ExamsSystem.BusinessLogic.Interfaces;
using ExamsSystem.Data.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExamsSystem.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorsController : ControllerBase
    {
        private readonly IExamService _examService;
        private readonly ICourseService _courseService;

        public ProfessorsController(IExamService examService,
            ICourseService courseService)
        {
            _examService = examService;
            _courseService = courseService;
        }


        [HttpGet("index")]
        public IActionResult Index()
        {
            _examService.GetData();
            return Ok();
        }

        [HttpGet("{professorId}/courses")]
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

        [HttpGet("{professorId}/exams/{examId}")]
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

        [HttpGet("{professorId}/exams")]
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

        [HttpPost("{professorId}/courses/{courseId}/exams")]
        public HttpResponseMessage EditExam(int professorId, int courseId, [FromBody]Exam exam)
        {
            
            /*
            var checkIfExists = _courseService.GetCourseById(professorId, courseId);//verficam daca profesorul preda cursul ala
             
            if (idExam == null)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            else
            {
                _examService.CreateExam(exam);
            }
            return new HttpResponseMessage(HttpStatusCode.OK);*/
            _examService.CreateExam(exam);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
