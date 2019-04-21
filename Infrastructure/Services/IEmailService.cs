namespace GFT.Starter.Infrastructure.Services
{
    public interface IEmailService
    {
        void SendEmail(string subject, string body);
    }
}