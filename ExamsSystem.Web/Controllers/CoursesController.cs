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
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CoursesController(ICourseService classroomService)
        {
            _courseService = classroomService;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetCourses()
        {
            try
            {
                return Ok(_courseService.GetCourses());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}