using MimeKit;
using MailKit.Net.Smtp;
using Misc.Services.EmailService.Models;

namespace Misc.Services.EmailService
{
    public class EmailService : IEmailService
    {
        //private readonly EmailConfiguration _emailConfig;

        //public EmailService(EmailConfiguration emailConfig)
        //{
        //    _emailConfig = emailConfig;
        //}

        //public void SendEmail(Message message)
        //{
        //    var emailMessage = CreateEmailMessage(message);
        //    Send(emailMessage);
        //}

        //private MimeMessage CreateEmailMessage(Message message)
        //{
        //    var emailMessage = new MimeMessage();
        //    emailMessage.From.Add(new MailboxAddress(_emailConfig.From, "vzlommamonta@gmail.com"));
        //    emailMessage.To.AddRange(message.To);
        //    emailMessage.Subject = message.Subject;
        //    emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = message.Content };
        //    return emailMessage;
        //}
        //private void Send(MimeMessage mailMessage)
        //{
        //    using (var client = new SmtpClient())
        //    {
        //        try
        //        {
        //            client.Connect(_emailConfig.SmtpServer, _emailConfig.Port, true);
        //            client.AuthenticationMechanisms.Remove("XOAUTH2");
        //            client.Authenticate(_emailConfig.UserName, _emailConfig.Password);
        //            client.Send(mailMessage);
        //        }
        //        catch
        //        {
        //            //log an error message or throw an exception or both.
        //            throw;
        //        }
        //        finally
        //        {
        //            client.Disconnect(true);
        //            client.Dispose();
        //        }
        //    }
        //}
        public void SendGmail(EmailModel emailModel)
        {
            MimeMessage message = new MimeMessage();
            message.From.Add(new MailboxAddress($"{emailModel.name}", ""));
            message.To.Add(new MailboxAddress("", "olegsolovyanenko@gmail.com"));
            message.Body = new BodyBuilder() { HtmlBody = $"<div>Номер телефона: {emailModel.mobileNumber}</div><div>{emailModel.message}</div>" }.ToMessageBody();

            using (MailKit.Net.Smtp.SmtpClient client = new MailKit.Net.Smtp.SmtpClient())
            {
                client.Connect("smtp.gmail.com", 465, true);
                client.Authenticate("vzlommamonta@gmail.com", "r6dlZ4fHHA");
                client.Send(message);

                client.Disconnect(true);
            }
        }

    }

}
