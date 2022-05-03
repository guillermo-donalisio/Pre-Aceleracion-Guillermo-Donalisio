namespace Api_Disney.Services;

public interface IMailService
{
	Task SendEmailAsync(string toEmail);
}
