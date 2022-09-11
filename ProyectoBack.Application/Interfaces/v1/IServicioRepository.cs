using ProyectoBack.Core.Entities.v1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBack.Application.Interfaces.v1
{
    public interface IServicioRepository : IRepository<clsUsuario, int>
    {   
        Task<clsUsuario> obtenerUsuarios(string usuario);
        Task<List<clsProducto>> obtenerProductos();
        Task<List<clsInventario>> obtenerInventarios();
        Task<clsProducto> obtenerUnProductoAsNotTracking(int id);
        Task<clsInventario> obtenerUnInventarioAsNotTracking(int id);
        Task<clsInventario> obtenerUnInventarios(int id);
    }
}
