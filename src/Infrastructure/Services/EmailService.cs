using System.Net.Mail;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Services;

public interface IEmailService
{
    Task SendWelcomeEmailAsync(string toEmail, string employeeName);
}

public class EmailService : IEmailService
{
    private readonly IConfiguration _config;
    
    public EmailService(IConfiguration config)
    {
        _config = config;
    }
    
    public async Task SendWelcomeEmailAsync(string toEmail, string employeeName)
    {
        var smtpHost = _config["Smtp:Host"] ?? "smtp.gmail.com";
        var smtpPort = int.Parse(_config["Smtp:Port"] ?? "587");
        var smtpUser = _config["Smtp:User"] ?? "tuemail@gmail.com";
        var smtpPass = _config["Smtp:Password"] ?? "tuapppassword";
        
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("TalentoPlus", smtpUser));
        message.To.Add(new MailboxAddress(employeeName, toEmail));
        message.Subject = "Bienvenido a TalentoPlus";
        message.Body = new TextPart("html")
        {
            Text = $@"
                <h1>¡Bienvenido {employeeName}!</h1>
                <p>Tu registro en TalentoPlus ha sido exitoso.</p>
                <p>Ya puedes acceder al sistema con tus credenciales.</p>
            "
        };
        
        using var client = new SmtpClient();
        
        try
        {
            await client.ConnectAsync(smtpHost, smtpPort, SecureSocketOptions.StartTls);
            await client.AuthenticateAsync(smtpUser, smtpPass);
            await client.SendAsync(message);
            await client.DisconnectAsync(true);
        }
        catch (Exception ex)
        {
            // Para examen: solo log
            Console.WriteLine($"Email error: {ex.Message}");
            // En producción no usar Console
        }
    }
}

