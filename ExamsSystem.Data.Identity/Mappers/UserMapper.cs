using System;
using System.Collections.Generic;
using System.Text;
using ExamsSystem.Data.Identity.Models;
using ExamsSystem.Data.Models.Models;

namespace ExamsSystem.Data.Identity.Mappers
{
    public static class UserMapper
    {
        public static UserViewModel GetBlModel(this User item)
        {
            var blItem = new UserViewModel()
            {
                Id = item.Id,
                Email = item.Email,
                FirstName = item.FirstName,
                LastName = item.LastName,
            };

            return blItem;
        }
    }
}
