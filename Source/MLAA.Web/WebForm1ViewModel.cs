using MLAA.Data.Linq2Sql.Domain.Services;

namespace MLAA.Web
{
    public class WebForm1ViewModel
    {
        private readonly IStudentEnrolmentService _enrolmentService;

        public WebForm1ViewModel(IStudentEnrolmentService enrolmentService)
        {
            _enrolmentService = enrolmentService;
        }

        public void EnrolStudentInSubject(int userId, int subjectId)
        {
            _enrolmentService.EnrolStudentInSubject(userId, subjectId);
        }
    }
}