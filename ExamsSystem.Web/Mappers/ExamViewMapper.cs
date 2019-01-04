using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamsSystem.BusinessLogic.Models;
using ExamsSystem.Web.Models;

namespace ExamsSystem.Web.Mappers
{
    public static class ExamViewMapper
    {
        public static ExamBlModel GetBlModel(this ExamViewModel item)
        {
            var blItem = new ExamBlModel()
            {
                Id = item.Id,
                CourseId = item.CourseId,
                Date = item.Date,
                Description = item.Description,
                FinishHour = item.FinishHour,
                ProfessorId = item.ProfessorId,
                StartHour = item.StartHour,
                Title = item.Title,
            };
            return blItem;
        }
    }
}
