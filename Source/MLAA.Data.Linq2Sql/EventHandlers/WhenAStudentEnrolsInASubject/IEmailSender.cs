using System.Net.Mail;

namespace MLAA.Data.Linq2Sql.EventHandlers.WhenAStudentEnrolsInASubject
{
    public interface IEmailSender
    {
        void Send(MailMessage message);
    }
}