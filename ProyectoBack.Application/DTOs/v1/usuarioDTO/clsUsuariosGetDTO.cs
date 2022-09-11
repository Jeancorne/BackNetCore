using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBack.Application.DTOs.v1.usuarioDTO
{
    public class clsUsuariosGetDTO
    {
        public int id { get; set; }
        public string nombre { get; set; }        
        public string apellido { get; set; }        
        public string correo { get; set; }
        public string usuario { get; set; }
        public bool activo { get; set; }
        public DateTime fechaCreacion { get; set; }
        public DateTime fechaModificacion { get; set; }
    }
}
