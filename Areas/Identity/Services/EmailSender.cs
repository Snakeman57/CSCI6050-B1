using CineWeb.Areas.Identity.Services;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;
namespace WebPWrecover.Services;

public class EmailSender : IEmailSender
{
    private readonly ILogger _logger;

    public EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor,
                       ILogger<EmailSender> logger)
    {
        Options = optionsAccessor.Value;
        _logger = logger;
    }

    public AuthMessageSenderOptions Options { get; } //Set with Secret Manager.

    public async Task SendEmailAsync(string toEmail, string subject, string message)
    {
        MailAddress from = new MailAddress("msentell7@gmial.com", "B1 cinemas");
        MailAddress to = new MailAddress(toEmail);
        MailMessage msg = new MailMessage(from, to);
        msg.Subject = subject;
        msg.Body = message;
        SmtpClient client = new SmtpClient("localhost");
        client.Credentials = CredentialCache.DefaultNetworkCredentials;
        try {
            client.Send(msg);
        }
        catch(Exception e) {
            Console.WriteLine("Error emailing: {0}", e.ToString());
        }
    }
}