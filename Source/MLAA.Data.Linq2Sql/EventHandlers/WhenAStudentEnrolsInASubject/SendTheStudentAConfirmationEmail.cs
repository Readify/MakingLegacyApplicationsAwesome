using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;

namespace MLAA.Data.Linq2Sql.EventHandlers.WhenAStudentEnrolsInASubject
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
