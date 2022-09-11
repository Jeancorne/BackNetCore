using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProyectoBack.Core.Entities.v1
{
    public class clsProducto : BaseEntity<int>
    {   
        [Required]
        public string nombre { get; set; }
        [Required]
        public int? cantidadMinAlerta { get; set; }

        [JsonIgnore]
        public virtual ICollection<clsInventario> clsInventarios { get; set; }        
    }
}
