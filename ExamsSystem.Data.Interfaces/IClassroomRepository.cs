using System;
using System.Collections.Generic;
using System.Text;
using ExamsSystem.Data.Models.Models;

namespace ExamsSystem.Data.Interfaces
{
    public interface IClassroomRepository
    {
        IEnumerable<Classroom> GetClassrooms();
        Classroom GetClassroomById(int classroomId);
    }
}
