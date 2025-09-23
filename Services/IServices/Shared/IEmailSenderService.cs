namespace Services.IServices.Shared
{
    public interface IEmailSenderService
    {        
        Task SendEmailAsync(
          string toEmail,
          string subject,
          string body,
          string moduleKey
      );
    }
}
