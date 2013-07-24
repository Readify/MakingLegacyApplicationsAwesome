using System.Net.Mail;

namespace MLAA.Data.Linq2Sql.Domain.EventHandlers.WhenAStudentEnrolsInASubject
{
    public class SendTheStudentAConfirmationEmail: IHandle<StudentEnrolledInSubjectEvent>
    {
        private readonly IEmailSender _emailSender;

        public SendTheStudentAConfirmationEmail(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        public void Handle(StudentEnrolledInSubjectEvent domainEvent)
        {
            var message = new MailMessage("from@example.com",
                "to@example.com",
                "Subject",
                "Congratulations");

            _emailSender.Send(message);
        }
    }
}
