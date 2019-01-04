using System.Collections.Generic;
using System.Linq;
using ExamsSystem.BusinessLogic.Implementation.Mappers;
using ExamsSystem.BusinessLogic.Interfaces;
using ExamsSystem.BusinessLogic.Models;
using ExamsSystem.Data.Interfaces;

namespace ExamsSystem.BusinessLogic.Implementation.Services
{
    public class ClassroomService: IClassroomService
    {
        private readonly IClassroomRepository _classroomRepository;

        public ClassroomService(IClassroomRepository classroomRepository)
        {
            _classroomRepository = classroomRepository;
        }
        public IEnumerable<ClassroomBlModel> GetClassrooms()
        {
            return _classroomRepository.GetClassrooms().Select(c => c.GetBlModel());
        }

        public ClassroomBlModel GetClassroomById(int classroomId)
        {
            return _classroomRepository.GetClassroomById(classroomId).GetBlModel();
        }
    }
}
