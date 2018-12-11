using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamsSystem.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Http;
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
    }
}