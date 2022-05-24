namespace Portfolio.Misc.Services;

public interface IEmailService
{
    Task Send(string email, string subject, string message);
    
}