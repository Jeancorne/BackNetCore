using System.ComponentModel.DataAnnotations;

namespace ProyectoBack.Application.DTOs.v1.usuarioDTO
{
    public class clsUsuariosPutDTO
    {
        [Required]
        public int id { get; set; }
        [Required]
        public string nombre { get; set; }
        [Required]
        public string apellido { get; set; }
        [Required]
        public string correo { get; set; }
        [Required]
        public string usuario { get; set; }
        [Required]
        public bool activo { get; set; }
    }
}
