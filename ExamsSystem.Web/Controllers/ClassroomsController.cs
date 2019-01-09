using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamsSystem.BusinessLogic.Interfaces;
using ExamsSystem.Web.Mappers;
using ExamsSystem.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamsSystem.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassroomsController : ControllerBase
    {
        private readonly IClassroomService _classroomService;

        public ClassroomsController(IClassroomService classroomService)
        {
            _classroomService = classroomService;
        }

//        [Authorize(Policy = "Professor")]
//        [HttpPost("{professorId:int}/exams")]
//        public IActionResult CreateExam([FromBody] ExamViewModel exam)
//        {
//
//
//            var examBlModel = exam.GetBlModel();
//
//            _examService.CreateExam(examBlModel, exam.Classrooms);
//            return NoContent();
//        }
    }
}