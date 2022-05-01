using Api_Disney.Repositories;

namespace Api_Disney.Services.Implements;

public class MailService : IMailService
{
    private IMailRepository _mailRepository;

    public MailService(IMailRepository mailRepository)
    {
        this._mailRepository = mailRepository;   
    }
    public async Task SendEmailAsync(string toEmail, string subject, string content)
    {
        await _mailRepository.SendEmailAsync(toEmail, subject, content);
    }
}
