namespace Portfolio.Misc.Services;

using MimeKit;
using MailKit.Net.Smtp;
using System.Threading.Tasks;

    public class EmailService : IEmailService
    {
        public async Task Send(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("Admin", "admin@tyuop.tk"));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.yandex.ru", 465, true);
                Console.WriteLine("did");
                await client.AuthenticateAsync("admin@tyuop.tk", Environment.GetEnvironmentVariable("EmailPassword"));
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }
        }
    }
