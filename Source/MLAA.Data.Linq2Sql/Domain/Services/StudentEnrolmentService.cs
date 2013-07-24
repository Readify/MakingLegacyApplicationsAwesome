using System.Linq;

namespace MLAA.Data.Linq2Sql.Domain.Services
{
    public class StudentEnrolmentService : IStudentEnrolmentService
    {
        private readonly DerpUniversityDataContext _db;

        public StudentEnrolmentService(DerpUniversityDataContext db)
        {
            _db = db;
        }

        public void EnrolStudentInSubject(int studentId, int subjectId)
        {
            var student = _db.Students.First(stu => stu.Id == studentId);
            var subject = _db.Subjects.First(subj => subj.Id == subjectId);

            student.EnrolIn(subject);
        }
    }
}