using Microsoft.Extensions.Options;
using ProyectoBack.Application.Custom;
using ProyectoBack.Application.Interfaces.v1;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ProyectoBack.Application.Services.v1
{
    public class EmailServices : IEmailServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly MailSettings _smtpSettings;
        public EmailServices(IUnitOfWork unitOfWork, IOptions<MailSettings> mailSettings)
        {
            _smtpSettings = mailSettings.Value;
            _unitOfWork = unitOfWork;            
        }
        public async Task EnviarCorreo(string correo)
        {
            //Settings         
            string host = _smtpSettings.Servidor;
            string port = _smtpSettings.Puerto.ToString();
            string usuario = _smtpSettings.Correo;
            string password = _smtpSettings.Password;
            string mailSender = _smtpSettings.Correo;
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(mailSender);
                mail.To.Add(correo);
                mail.Subject = "Inventario";
                mail.Body = "Inventario cantidad";
                mail.IsBodyHtml = true;
                using (SmtpClient smtp = new SmtpClient(host, int.Parse(port)))
                {
                    smtp.Credentials = new NetworkCredential(usuario, password);
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }
        }
    }
}
