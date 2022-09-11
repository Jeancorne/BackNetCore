using System.ComponentModel.DataAnnotations;

namespace ProyectoBack.Application.DTOs.v1.productoDTO
{
    public class clsProductoDTO
    {
        [Required]
        public int? id { get; set; }
        [Required]
        public string nombre { get; set; }
        [Required]
        public int? cantidadMinAlerta { get; set; }
    }
}
