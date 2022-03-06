
using Misc.Services.EmailService.Models;

namespace Misc.Services.EmailService
{
    public interface IEmailService
    {
        public void SendGmail(EmailModel emailModel);

        //public void SendEmail(Message message);
    }
}
