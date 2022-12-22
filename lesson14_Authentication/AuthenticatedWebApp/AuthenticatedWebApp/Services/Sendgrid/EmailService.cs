using Microsoft.AspNetCore.Identity.UI.Services;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace AuthenticatedWebApp.Services.Sendgrid
{
    public class EmailSender : IEmailSender
    {
        private readonly ILogger _logger;
        private readonly string _key;

        public EmailSender(ILogger<EmailSender> logger)
        {
            var apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
            if (string.IsNullOrEmpty(apiKey))
            {
                throw new ArgumentNullException("SENDGRID_API_KEY", "Could not find the API key in the Environment variables");
            }
            _key = apiKey;
            _logger = logger;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string message)
        {
            await Execute(_key, subject, message, toEmail);
        }

        public async Task Execute(string apiKey, string subject, string message, string toEmail)
        {
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("i2.ilin@itransition.com", "Password Recovery"),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress(toEmail));

            // Disable click tracking.
            // See https://sendgrid.com/docs/User_Guide/Settings/tracking.html
            msg.SetClickTracking(false, false);

            var response = await client.SendEmailAsync(msg);

            _logger.LogInformation(response.IsSuccessStatusCode
                                   ? $"Email to {toEmail} queued successfully!"
                                   : $"Failure Email to {toEmail}");
        }
    }
}
