using Api_Disney.Repositories;

namespace Api_Disney.Services.Implements;

public class MailService : IMailService
{
    private IMailRepository _mailRepository;

    public MailService(IMailRepository mailRepository)
    {
        this._mailRepository = mailRepository;   
    }
    public async Task SendEmailAsync(string toEmail)
    {
        await _mailRepository.SendEmailAsync(toEmail);
    }
}
