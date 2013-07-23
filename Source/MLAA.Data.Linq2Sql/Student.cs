using System.Linq;

namespace MLAA.Data.Linq2Sql
{
    public partial class Student
    {
        public void EnrolIn(Subject subject)
        {
            subject.AcceptEnrolmentFor(this);
        }

        public bool IsEnrolledIn(Subject subject)
        {
            return StudentSubjectEnrolments
                .Where(sse => sse.SubjectId == subject.Id)
                .Any();
        }
    }
}