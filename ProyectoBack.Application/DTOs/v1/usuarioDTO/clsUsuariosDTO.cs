using System.ComponentModel.DataAnnotations;

namespace ProyectoBack.Application.DTOs.v1.POST
{
    
    public class clsUsuariosDTO 
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
    }   
}
