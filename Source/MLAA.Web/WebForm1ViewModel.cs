using System.Linq;
using MLAA.Data.Linq2Sql;

namespace MLAA.Web
{
    public class WebForm1ViewModel
    {
        public void EnrolStudentInSubject(int userId, int subjectId)
        {
            using (var db = new DerpUniversityDataContext())
            {
                var student = db.Students.First(stu => stu.Id == userId);
                var subject = db.Subjects.First(subj => subj.Id == subjectId);

                student.EnrolIn(subject);

                db.SubmitChanges();
            }
        }
    }
}