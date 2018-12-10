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

        public ProfessorsController(IExamService examService)
        {
            _examService = examService;
        }


        [HttpGet("index")]
        public IActionResult Index()
        {
            return Ok("works");
        }
    }
}