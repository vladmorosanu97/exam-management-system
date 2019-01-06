using System;
using System.Collections.Generic;
using System.Text;

namespace ExamsSystem.BusinessLogic.Models
{
    public class UserCourseBlModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public UserBlModel User { get; set; }

        public int CourseId { get; set; }
        public CourseBlModel Course { get; set; }
    }
}
