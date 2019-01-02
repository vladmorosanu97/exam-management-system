using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExamsSystem.Data.Interfaces;
using ExamsSystem.Data.Models.Models;

namespace ExamsSystem.Data.Implementation
{
    public class ClassroomRepository: IClassroomRepository
    {
        private readonly DatabaseContext _databaseContext;

        public ClassroomRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public IEnumerable<Classroom> GetClassrooms()
        {
            return _databaseContext.Classrooms.ToList();
        }

        public Classroom GetClassroomById(int classroomId)
        {
            return _databaseContext.Classrooms.FirstOrDefault(c => c.Id == classroomId);
        }
    }
}
