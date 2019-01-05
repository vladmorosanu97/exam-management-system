using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ExamsSystem.Data.Identity.Models;

namespace ExamsSystem.Data.Identity
{
    public interface IAppUserManager
    {
        Task<UserViewModel> Create(UserRegisterViewModel model);
        Task<UserViewModel> CheckCredentials(string email, string password);
        Task<JwtTokenViewModel> GenerateToken(UserViewModel userViewModel);
    }
}
