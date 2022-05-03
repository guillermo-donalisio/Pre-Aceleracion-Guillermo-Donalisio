using SendGrid;
using SendGrid.Helpers.Mail;

namespace Api_Disney.Repositories.Implements;

public class MailRepository : IMailRepository
{
    private IConfiguration _configuration;

    public MailRepository(IConfiguration configuration)
    {
        this._configuration = configuration;
    }

    public async Task SendEmailAsync(string toEmail)
    {
        var apiKey = _configuration["SendGrid:ApiKey"];
        var client = new SendGridClient(apiKey);
        var from = new EmailAddress("guillermo.donalisio1@gmail.com", "Testing Auth email");
        var subject = "Verify your email";
        var to = new EmailAddress(toEmail);
        var plainTextContent = "Mail sent by SendGrid with C#";
        var htmlContent = "<strong>Mail sent by SendGrid with C#</strong>";
        var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
        var response = await client.SendEmailAsync(msg);
    }
}
