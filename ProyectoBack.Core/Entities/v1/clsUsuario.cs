using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBack.Core.Entities.v1
{
    public class clsUsuario : BaseEntity<int>
    {
        [Required]
        public string nombre { get; set; }
        [Required]
        public string apellido { get; set; }
        [Required]
        public string correo { get; set; }
        [Required]
        public string usuario { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public bool activo { get; set; }
    }
}
