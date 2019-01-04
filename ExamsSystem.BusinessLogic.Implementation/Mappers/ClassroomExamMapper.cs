using System;
using System.Collections.Generic;
using System.Text;
using ExamsSystem.BusinessLogic.Models;
using ExamsSystem.Data.Models.Models;

namespace ExamsSystem.BusinessLogic.Implementation.Mappers
{
    public static class ClassroomExamMapper
    {
        public static ClassroomExamBlModel GetBlModel(this ClassroomExam item)
        {
            var blItem = new ClassroomExamBlModel()
            {
                Classroom = item.Classroom?.GetBlModel(),
                ClassroomId = item.ClassroomId
            };
            return blItem;
        }

        public static ClassroomExam GetDataModel(this ClassroomExamBlModel item)
        {
            var blItem = new ClassroomExam()
            {
                Classroom = item.Classroom?.GetDataModel(),
                ClassroomId = item.ClassroomId,
                Exam = item.Exam?.GetDataModel(),
                ExamId = item.ExamId
            };
            return blItem;
        }
    }
}
