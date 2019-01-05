using System;
using System.Collections.Generic;
using System.Text;

namespace ExamsSystem.Data.Identity.Models
{
    public class JwtTokenViewModel
    {
        public string access_token { get; set; }
        public int expires_in { get; set; }
        public string token_type => "Bearer";

    }
}
