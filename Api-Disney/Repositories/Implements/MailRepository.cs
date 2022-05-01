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

    public async Task SendEmailAsync(string toEmail, string subject, string content)
    {
        var apiKey = _configuration["SendGrid:ApiKey"];
        var client = new SendGridClient(apiKey);
        var from = new EmailAddress("guillermo.donalisio1@gmail.com", "JWT Auth email");
        //var subject = "Verify your acoount";
        var to = new EmailAddress(toEmail);
        //var plainTextContent = "and easy to do anywhere, even with C#";
        //var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
        var msg = MailHelper.CreateSingleEmail(from, to, subject, content, content);
        var response = await client.SendEmailAsync(msg);
    }
}
