namespace MLAA.Data.Linq2Sql.Domain.Services
{
    public interface IStudentEnrolmentService: IDomainService
    {
        void EnrolStudentInSubject(int studentId, int subjectId);
    }
}