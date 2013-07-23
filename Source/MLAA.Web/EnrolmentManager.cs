using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using MLAA.Data.Linq2Sql;

namespace MLAA.Web
{
   
    public static class EnrolmentManager
    {
        public static bool IsEnrolled(int studentId, int subjectId)
        {
            using (var db = new DerpUniversityDataContext())
            {
                var student = db.Students.First(s => s.Id == studentId);
                return student.StudentSubjectEnrolments.Any(sse => sse.SubjectId == subjectId);
            }
        }

        /// <summary>
        /// Searches for a student by name.
        /// </summary>
        /// <param name="name">Any Part of the first name or last name of the student.</param>
        /// <returns></returns>
        public static Student[] SearchStudents(string name)
        {
            using (var db = new DerpUniversityDataContext())
            {
                var students = db.Students
                                 .Where(s => s.LastName.Contains(name))
                                 .ToArray();
                return students;
            }
        }

        public static Subject[] GetStudentEnrolments(int id)
        {
            using (var db = new DerpUniversityDataContext())
            {
                var subjects = db.Students
                                 .First(s => s.Id == id)
                                 .StudentSubjectEnrolments
                                 .Select(sse => sse.Subject)
                                 .ToArray();
                return subjects;
            }
        }
    }
}