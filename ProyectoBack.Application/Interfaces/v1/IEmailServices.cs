using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBack.Application.Interfaces.v1
{
    public interface IEmailServices
    {
        Task EnviarCorreo(string correo);
    }
}
