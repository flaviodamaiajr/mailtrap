using Mailtrap.Source.Interfaces;
using Mailtrap.Source.Models;
using Mailtrap.Source.Resources;
using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;

public class MailtrapSender : IMailtrapSender, IDisposable
{
    private readonly SmtpClient _smtpClient;
    private static readonly int[] Ports = { 25, 465, 2525 };
    private const string SmtpMailtrap = "smtp.mailtrap.io";

    public void Dispose() => _smtpClient?.Dispose();

    public MailtrapSender(string userName, string password, int? port = null)
    {
        if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password))
        {
            throw new ArgumentException(ExceptionsMessages.Invalid_Credential);
        }

        if (port.HasValue && !Ports.Contains(port.Value))
        {
            throw new ArgumentException(ExceptionsMessages.Invalid_Port, nameof(port));
        }

        _smtpClient = new SmtpClient(SmtpMailtrap, port.GetValueOrDefault(2525))
        {
            Credentials = new NetworkCredential(userName, password),
            EnableSsl = true
        };
    }

    public void Send(Email email)
    {
        var mailMessage = new MailMessage(email.From, email.To, email.Subject, email.Body)
        {
            IsBodyHtml = email.IsBodyHtml
        };

        _smtpClient.Send(mailMessage);
    }

    public Task SendAsync(Email email, CancellationToken cancellationToken = default)
    {
        var mailMessage = new MailMessage(email.From, email.To, email.Subject, email.Body)
        {
            IsBodyHtml = email.IsBodyHtml
        };

        _smtpClient.SendAsync(mailMessage, cancellationToken);
        return Task.CompletedTask;
    }
}