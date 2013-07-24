using System.Net.Mail;

namespace MLAA.Data.Linq2Sql
{
    public interface IEmailSender
    {
        void Send(MailMessage message);
    }
}