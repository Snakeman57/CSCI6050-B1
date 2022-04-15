using System.Net;
using System.Net.Mail;
using CineWeb.Areas.Identity.Services;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace WebPWrecover.Services;

public class EmailSender : IEmailSender
{
    public EmailSender()
        {
 
        }
 

    public AuthMessageSenderOptions Options { get; } //Set with Secret Manager.

    public async Task SendEmailAsync(string toEmail, string subject, string MailMessage)
    {
        string fromMail = "[lpham1357@gmail.com]";
            string fromPassword = "[bbpykxpxwdbfjwhs]";
 
            MailMessage message = new MailMessage();
            message.From = new MailAddress(fromMail);
            message.Subject = subject;
            message.To.Add(new MailAddress(toEmail));
            message.Body ="<html><body> " + MailMessage + " </body></html>";
            message.IsBodyHtml = true;
 
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(fromMail, fromPassword),
                EnableSsl = true,
            };
            smtpClient.Send(message);
    }
}