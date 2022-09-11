using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBack.Application.DTOs.v1.InventarioDTO
{
    public class clsInventariocrearDTO
    {
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
        public byte[] documento { get; set; }
        public string? nombreDocumento { get; set; }
    }
}
