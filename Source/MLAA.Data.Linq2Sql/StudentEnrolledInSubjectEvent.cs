namespace MLAA.Data.Linq2Sql
{
    public class StudentEnrolledInSubjectEvent
    {
        private readonly Student _student;
        private readonly Subject _subject;

        public StudentEnrolledInSubjectEvent(Student student, Subject subject)
        {
            _student = student;
            _subject = subject;
        }

        public Student Student
        {
            get { return _student; }
        }

        public Subject Subject
        {
            get { return _subject; }
        }
    }
}