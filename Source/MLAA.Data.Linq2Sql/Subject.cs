using System;
using System.Linq;

namespace MLAA.Data.Linq2Sql
{
    public partial class Subject
    {
        internal void AcceptEnrolmentFor(Student student)
        {
            if (IsEnrolled(student)) throw new InvalidOperationException("Student is already enrolled.");

            StudentSubjectEnrolments.Add(new StudentSubjectEnrolment
            {
                Student = student,
                Subject = this,
            });

            DomainEvents.Raise(new StudentEnrolledInSubjectEvent(student, this));
        }

        private bool IsEnrolled(Student student)
        {
            return StudentSubjectEnrolments
                .Where(sse => sse.StudentId == student.Id)
                .Any();
        }
    }
}