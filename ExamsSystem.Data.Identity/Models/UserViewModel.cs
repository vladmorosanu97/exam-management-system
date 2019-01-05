﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ExamsSystem.Data.Identity.Models
{
    public class UserViewModel
    {
        public int? Id { get; set; }
        public string Email { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Role { get; set; }
    }
}
