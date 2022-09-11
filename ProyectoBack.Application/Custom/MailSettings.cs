using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBack.Application.Custom
{
    public class MailSettings
    {
        public string Servidor { get; set; }
        public int Puerto { get; set; }
        public string SenderNombre { get; set; }
        public string Correo { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
    }
}
