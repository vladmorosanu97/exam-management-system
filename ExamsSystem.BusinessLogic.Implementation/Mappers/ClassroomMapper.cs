using System;
using System.Collections.Generic;
using System.Text;
using ExamsSystem.BusinessLogic.Models;
using ExamsSystem.Data.Models.Models;

namespace ExamsSystem.BusinessLogic.Implementation.Mappers
{
    public static class ClassroomMapper
    {
        public static ClassroomBlModel GetBlModel(this Classroom item)
        {
            var blItem = new ClassroomBlModel()
            {
                Id = item.Id,
                Name = item.Name
            };
            return blItem;
        }

        public static Classroom GetDataModel(this ClassroomBlModel blItem)
        {
            var item = new Classroom()
            {
                Id = blItem.Id,
                Name = blItem.Name
            };
            return item;
        }
    }
}
