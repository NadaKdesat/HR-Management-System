using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

public class EmailService
{
    private readonly string _smtpServer = "smtp.your-email-provider.com"; 
    private readonly int _smtpPort = 587;
    private readonly string _smtpUser = "your-email@example.com"; 
    private readonly string _smtpPass = "your-email-password"; 

    public async Task SendEmailAsync(string toEmail, string subject, string body)
    {
        using (var client = new SmtpClient(_smtpServer, _smtpPort))
        {
            client.Credentials = new NetworkCredential(_smtpUser, _smtpPass);
            client.EnableSsl = true;

            var mailMessage = new MailMessage
            {
                From = new MailAddress(_smtpUser),
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };
            mailMessage.To.Add(toEmail);

            await client.SendMailAsync(mailMessage);
        }
    }
}
