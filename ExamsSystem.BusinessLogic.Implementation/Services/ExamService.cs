using ExamsSystem.BusinessLogic.Implementation.Mappers;
//using ExamsSystem.BusinessLogic.Interfaces;
using ExamsSystem.BusinessLogic.Models;
using ExamsSystem.Data.Interfaces;
using ExamsSystem.Data.Models.Models;
using System.Collections.Generic;
using System.Linq;
using ExamsSystem.BusinessLogic.Interfaces;

namespace ExamsSystem.BusinessLogic.Implementation.Services
{
    public class ExamService: IExamService
    {
        private readonly IExamRepository _examRepository;
        private readonly IClassroomRepository _classroomRepository;

        public ExamService(IExamRepository examRepository,
            IClassroomRepository classroomRepository)
        {
            _examRepository = examRepository;
            _classroomRepository = classroomRepository;
        }

        public void GetData()
        {
            _examRepository.GetDataTest();
        }

        public ExamBlModel GetExamById(int professorId, int examId)
        {
            return _examRepository.GetExamById(examId).GetBlModel();
        }

        public IEnumerable<ExamBlModel> GetExamsByProfessorId(int professorId)
        {
            return _examRepository.GetExamsByProfessorId(professorId).Select(c => c.GetBlModel());
        }

        public void CreateExam(ExamBlModel exam, List<int> classroomsList)
        {
            var classrooms = new List<ClassroomBlModel>();
            foreach (var classroomId in classroomsList)
            {
                var classroom = _classroomRepository.GetClassroomById(classroomId);
                classrooms.Add(classroom.GetBlModel());
            }

            var examId = _examRepository.CreateExam(exam.GetDataModel());

            exam.Id = examId;
            var classroomExams = new List<ClassroomExamBlModel>();
            
            foreach (var classroom in classrooms)
            {
                var classroomExam = new ClassroomExamBlModel()
                {
                    ClassroomId = classroom.Id,
                    ExamId = exam.Id
                };
                classroomExams.Add(classroomExam);
            }

            exam.ClassroomExams = classroomExams;
            _examRepository.EditExam(exam.GetDataModel());
        }

        public void EditExam(ExamBlModel exam, List<int> classroomsList)
        {
            var classrooms = new List<ClassroomBlModel>();
            foreach (var classroomId in classroomsList)
            {
                var classroom = _classroomRepository.GetClassroomById(classroomId);
                classrooms.Add(classroom.GetBlModel());
            }

            var classroomExams = new List<ClassroomExamBlModel>();

            foreach (var classroom in classrooms)
            {
                var classroomExam = new ClassroomExamBlModel()
                {
                    ClassroomId = classroom.Id,
                    ExamId = exam.Id
                };
                classroomExams.Add(classroomExam);
            }

            exam.ClassroomExams = classroomExams;
            _examRepository.EditExam(exam.GetDataModel());
        }

        public IEnumerable<ExamBlModel> GetExamsByStudentId(int studentId)
        {
            return _examRepository.GetExamsByStudentId(studentId).Select(c => c.GetBlModel());
        }

        public void MarkPresentAtExams(int userId, int examId)
        {
            _examRepository.MarkPresentAtExams(userId,examId);
        }
    }
}
