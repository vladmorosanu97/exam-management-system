using System;
using ExamsSystem.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Authorization;
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