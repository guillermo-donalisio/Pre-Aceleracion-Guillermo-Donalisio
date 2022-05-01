namespace Api_Disney.Repositories;

public interface IMailRepository
{
	Task SendEmailAsync(string toEmail, string subject, string content);
}
