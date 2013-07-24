using System.Net.Mail;

namespace MLAA.Data.Linq2Sql.EventHandlers.WhenAStudentEnrolsInASubject
{
    public class SendTheSubjectCoordinatorANotificationEmail : IHandle<StudentEnrolledInSubjectEvent>
    {
        private readonly IEmailSender _emailSender;

        public SendTheSubjectCoordinatorANotificationEmail(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        public void Handle(StudentEnrolledInSubjectEvent domainEvent)
        {
            var message = new MailMessage(
                "from@example.com",
                "coordinator@example.com",
                "Another unwashed student has enrolled in your subject",
                string.Format("{0} {1} has enrolled. Hooray.",
                              domainEvent.Student.FirstName,
                              domainEvent.Student.LastName));

            _emailSender.Send(message);
        }
    }
}