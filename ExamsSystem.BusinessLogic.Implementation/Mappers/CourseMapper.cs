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
                Title = item.Title
            };
            return blItem;
        }
    }
}
