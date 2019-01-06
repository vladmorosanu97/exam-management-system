﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace ExamsSystem.Data.Models.Models
{
    public class User: IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<UserCourse> UserCourses { get; set; }
    }
}
