namespace GFT.Starter.Infrastructure.Services.Contracts
{
    public interface IEmailService
    {
        void SendEmail(string subject, string body);
    }
}