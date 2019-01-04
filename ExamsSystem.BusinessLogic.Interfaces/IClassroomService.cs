using System;
using System.Collections.Generic;
using System.Text;
using ExamsSystem.BusinessLogic.Models;

namespace ExamsSystem.BusinessLogic.Interfaces
{
    public interface IClassroomService
    {
        IEnumerable<ClassroomBlModel> GetClassrooms();
        ClassroomBlModel GetClassroomById(int classroomId);
    }
}
