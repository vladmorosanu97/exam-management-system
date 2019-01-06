using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ExamsSystem.Data.Identity.Mappers;
using ExamsSystem.Data.Identity.Models;
using ExamsSystem.Data.Interfaces;
using ExamsSystem.Data.Models.Models;
using ExamsSystem.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace ExamsSystem.Data.Identity
{
    public class AppUserManager : IAppUserManager
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private readonly ICourseRepository _courseRepository;

        public AppUserManager(UserManager<User> userManager,
            IConfiguration configuration,
            ICourseRepository courseRepository)
        {
            _userManager = userManager;
            _configuration = configuration;
            _courseRepository = courseRepository;
        }

        public async Task<UserViewModel> Create(UserRegisterViewModel userViewModel)
        {
            var result = await _userManager.CreateAsync(new User
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

            var user = await _userManager.FindByEmailAsync(userViewModel.Email);
            await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, userViewModel.Role));


            var userCourses = new List<UserCourse>();

            foreach (var courseId in userViewModel.Courses)
            {
                var course = _courseRepository.GetCourseById(courseId);
                userCourses.Add(new UserCourse
                {
                    CourseId = course.Id,
                    UserId = user.Id
                });
            }

            user.UserCourses = userCourses;

            await _userManager.UpdateAsync(user);

            return user.GetBlModel();
        }





        public async Task<UserViewModel> CheckCredentials(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                throw new Exception($"The user with {email} does not exist.");
            }

            var passwordOk = await _userManager.CheckPasswordAsync(user, password);
            if (!passwordOk)
            {
                throw new Exception("Invalid username or password");
            }

            return user.GetBlModel();
        }

        public async Task<JwtTokenViewModel> GenerateToken(UserViewModel userViewModel)
        {
            var user = await _userManager.FindByEmailAsync(userViewModel.Email);
            if (user == null)
            {
                throw new Exception($"The user with {userViewModel.Email} does not exist.");
            }

            var userClaims = await _userManager.GetClaimsAsync(user);
            var claims = userClaims;

            claims.Add(new Claim(ClaimTypes.Email, userViewModel.Email));
            claims.Add(new Claim(ClaimTypes.Name, userViewModel.Email));
            claims.Add(new Claim("Role", userClaims.First(item => item.Type == ClaimTypes.Role).Value));
            claims.Add(new Claim("LastName", userViewModel.LastName ?? ""));
            claims.Add(new Claim("FirstName", user.FirstName ?? ""));


            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Tokens:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiresIn = DateTime.Now.AddDays(30);
            var token = new JwtSecurityToken(
                issuer: _configuration["Tokens:Issuer"],
                audience: _configuration["Tokens:Audience"],
                claims: claims,
                expires: expiresIn,
                signingCredentials: creds);
            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            var accessToken = new JwtTokenViewModel
            {
                access_token = tokenString,
                expires_in = (int)(expiresIn - DateTime.Now).TotalMinutes
            };

            return accessToken;
        }

    }
}