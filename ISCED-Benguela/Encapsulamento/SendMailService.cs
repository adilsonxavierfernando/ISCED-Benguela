using MailKit.Net.Smtp;
using Microsoft.Extensions.Hosting;
using MimeKit;
using System.Net;
//using System.Net.Mail;
//using System.Net.Mail;

//using System.Net.Mail;

namespace ISCED_Benguela.Encapsulamento
{
    public class SendMailService
    {
        private readonly string _smtpServer;
        private readonly int _smtpPort;
        private readonly string _smtpUser;
        private readonly string _smtpPass;
        //private readonly SmtpClient _smtpClient;
        private readonly string _fromEmail;

        public SendMailService()
        {
            string smtpServer = "smtp.gmail.com";
            int smtpPort = 587; // Ou o porto utilizado pelo seu servidor SMTP
            string smtpUser = "afenix.development@gmail.com";
            //string smtpPass = "ntgzrveykpsdnyfv";
            string smtpPass = "ntgz rvey kpsd nyfv";

            _smtpServer = smtpServer;
            _smtpPort = smtpPort;
            _smtpUser = smtpUser;
            _smtpPass = smtpPass;


            
            _fromEmail = _smtpUser;
        }

        public async Task SendEmail(string toEmail, string subject, string body, bool isHtml = false)
        {
            string fromName = "Portal ISCED-Benguela"; string fromEmail = _smtpUser;
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(fromName, fromEmail));
            message.To.Add(new MailboxAddress("", toEmail));
            message.Subject = subject;

            var bodyBuilder = new BodyBuilder { HtmlBody = isHtml ? body : null, TextBody = isHtml ? null : body };
            message.Body = bodyBuilder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                try
                {
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                    await client.ConnectAsync(_smtpServer, _smtpPort, MailKit.Security.SecureSocketOptions.StartTlsWhenAvailable);
                    await client.AuthenticateAsync(_smtpUser, _smtpPass);

                    await client.SendAsync(message);
                    Console.WriteLine("E-mail enviado com sucesso!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao enviar e-mail: {ex.Message}");
                }
                finally
                {
                    client.Disconnect(true);
                }
            }
        }

        //public async Task SendEmail(string toEmail, string subject, string body, bool isBodyHtml = false)
        //{
        //   var  _smtpClient = new SmtpClient(_smtpServer, _smtpPort)
        //    {
        //        Credentials = new NetworkCredential(_smtpUser, _smtpPass),
        //        EnableSsl = true
        //    };
        //    var mailMessage = new MailMessage
        //    {
        //        From = new MailAddress(_fromEmail),
        //        Subject = subject,
        //        Body = body,
        //        IsBodyHtml = isBodyHtml
        //    };
        //    mailMessage.To.Add(toEmail);

        //    try
        //    {
        //        await _smtpClient.SendMailAsync(mailMessage);
        //        Console.WriteLine("E-mail enviado com sucesso!");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Erro ao enviar e-mail: {ex.Message}");
        //    }
        //}
    }
}
