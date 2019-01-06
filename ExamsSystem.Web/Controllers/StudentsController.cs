using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamsSystem.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExamsSystem.Web.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IExamService _examService;

        public StudentsController(IExamService examService)
        {
            _examService = examService;
        }

        [Authorize(Policy = "Student")]
        [HttpGet("{studentId:int}/exams")]
        public IActionResult GetExamsByStudentId(int studentId)
        {
            try
            {
                return Ok(_examService.GetExamsByStudentId(studentId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}