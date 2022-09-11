using System.ComponentModel.DataAnnotations;

namespace ProyectoBack.Application.DTOs.v1.InventarioDTO
{
    public class clsInventarioactualizarDTO
    {
        [Required]
        public int? id { get; set; }
        [Required]
        public int? cantidadEntrada { get; set; }
        [Required]
        public int? idProducto { get; set; }
        [Required]
        public string codigo { get; set; }        
        [Required]
        public decimal? precio { get; set; }
        [Required]
        public string descripcion { get; set; }
        [Required]
        public int? cantidad { get; set; }
        public byte[] documento { get; set; }
        public string? nombreDocumento { get; set; }
    }
}
