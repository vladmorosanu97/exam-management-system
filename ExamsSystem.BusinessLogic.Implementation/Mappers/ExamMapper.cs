using System;
using System.Collections.Generic;
using System.Text;
using ExamsSystem.BusinessLogic.Models;
using ExamsSystem.Data.Models.Models;

namespace ExamsSystem.BusinessLogic.Implementation.Mappers
{
    public static class ExamMapper
    {
        public static ExamBlModel GetExamBlModel(this Exam item)
        {
            var blItem = new ExamBlModel
            {
                ProfessorId = item.ProfessorId,
                Description = item.Description,
                Title = item.Title,
                Date = item.Date,
                StartHour = item.StartHour,
                FinishHour = item.FinishHour
            };
            return blItem;
        }
    }
}
