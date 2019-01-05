using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using ExamsSystem.Data.Identity;
using ExamsSystem.Data.Identity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MicroLicence.Web.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/Accounts")]
    public class AccountsController : Controller
    {
        private readonly IAppUserManager _appUserManager;

        public AccountsController(IAppUserManager appUserManager)
        {
            _appUserManager = appUserManager;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterViewModel user)
        {
            try
            {
                await _appUserManager.Create(user);
                return Ok("Account Created!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel request)
        {
            try
            {
                var user = await _appUserManager.CheckCredentials(request.Username, request.Password);
                
                var token = await _appUserManager.GenerateToken(user);
                return Ok(token);
            }
            catch (Exception e)
            {
                return BadRequest("Invalid credentials!");
            }
        }

    }


}