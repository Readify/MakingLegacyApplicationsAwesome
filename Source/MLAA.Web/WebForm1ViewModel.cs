using System.Linq;
using MLAA.Data.Linq2Sql;

namespace MLAA.Web
{
    public class WebForm1ViewModel
    {
        private readonly DerpUniversityDataContext _db;

        public WebForm1ViewModel(DerpUniversityDataContext db)
        {
            _db = db;
        }

        public void EnrolStudentInSubject(int userId, int subjectId)
        {
            var student = _db.Students.First(stu => stu.Id == userId);
            var subject = _db.Subjects.First(subj => subj.Id == subjectId);

            student.EnrolIn(subject);
        }
    }
}