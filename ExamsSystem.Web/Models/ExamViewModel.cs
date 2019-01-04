using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamsSystem.Web.Models
{
    public class ExamViewModel
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int ProfessorId { get; set; }


        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? StartHour { get; set; }
        public DateTime? FinishHour { get; set; }
        
        public List<int> Classrooms { get; set; }
    }
}
