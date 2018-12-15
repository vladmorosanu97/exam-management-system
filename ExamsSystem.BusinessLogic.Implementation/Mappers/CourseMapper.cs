using System;
using System.Collections.Generic;
using System.Text;
using ExamsSystem.BusinessLogic.Models;
using ExamsSystem.Data.Models.Models;

namespace ExamsSystem.BusinessLogic.Implementation.Mappers
{
    public static class CourseMapper
    {
        public static CourseBlModel GetBlModel(this Course item)
        {
            var blItem = new CourseBlModel
            {
                ProfessorId = item.ProfessorId,
                Description = item.Description,
                Title = item.Title,
                Id = item.Id
                
            };
            return blItem;
        }

        public static Course GetDataModel(this CourseBlModel blItem)
        {
            var item = new Course
            {
                ProfessorId = blItem.ProfessorId,
                Description = blItem.Description,
                Title = blItem.Title,
                Id = blItem.Id
            };
            return item;
        }
    }
}
