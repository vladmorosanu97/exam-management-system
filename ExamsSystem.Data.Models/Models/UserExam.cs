using System;
using System.Collections.Generic;
using System.Text;

namespace ExamsSystem.Data.Models.Models
{
    public class UserExam: BaseEntity
    {
        private int courseId;

        public UserExam(int userId, int examId)
        {
            UserId = userId;
            ExamId = courseId;
        }

        public int UserId { get; set; }
        public User User { get; set; }

        public int ExamId { get; set; }
        public Exam Exam { get; set; }
    }
}
