using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExamsSystem.BusinessLogic.Models;
using ExamsSystem.Data.Models.Models;

namespace ExamsSystem.BusinessLogic.Implementation.Mappers
{
    public static class ExamMapper
    {
        public static ExamBlModel GetBlModel(this Exam item)
        {
            var blItem = new ExamBlModel()
            {
                Description = item.Description,
                Title = item.Title,
                Date = item.Date,
                StartHour = item.StartHour,
                FinishHour = item.FinishHour,
                Course =  item.Course?.GetBlModel(),
                ClassroomExams = item.ClassroomExams?.Select(e => e.GetBlModel()).ToList(),
                Id = item.Id
            };
            return blItem;
        }

        public static Exam GetDataModel(this ExamBlModel blItem)
        {
            var item = new Exam
            {
                Description = blItem.Description,
                Title = blItem.Title,
                Date = blItem.Date,
                StartHour = blItem.StartHour,
                FinishHour = blItem.FinishHour,
                Course = blItem.Course?.GetDataModel(),
                Id = blItem.Id,
                CourseId = blItem.CourseId,
                ProfessorId = blItem.ProfessorId,
                ClassroomExams = blItem.ClassroomExams?.Select(e => e.GetDataModel()).ToList()
            };
            return item;
        }
    }
}
