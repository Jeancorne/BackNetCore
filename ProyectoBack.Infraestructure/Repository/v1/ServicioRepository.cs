using AppBack.Infraestructure.Repository;
using Microsoft.EntityFrameworkCore;
using ProyectoBack.Application.Interfaces.v1;
using ProyectoBack.Core.Entities.v1;
using ProyectoBack.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBack.Infraestructure.Repository.v1
{
    public class ServicioRepository : BaseRepository<clsUsuario, int>, IServicioRepository
    {
        public ServicioRepository(DBContext context) : base(context)
        {
        }

        public async Task<clsUsuario> obtenerUsuarios(string usuario)
        {
            var data = await _context.clsUsuario.Where(a => a.usuario == usuario.Trim()).FirstOrDefaultAsync();            
            return data;
        }
        public async Task<List<clsProducto>> obtenerProductos()
        {
            return await _context.clsProducto.ToListAsync();            
        }
        public async Task<List<clsInventario>> obtenerInventarios()
        {
            return await _context.clsInventario.Include(a => a.idProductoNavigation).ToListAsync();
        }
        public async Task<clsInventario> obtenerUnInventarios(int id)
        {
            return await _context.clsInventario.Where(a => a.id == id).Include(a => a.idProductoNavigation).FirstOrDefaultAsync();
        }


        public async Task<clsProducto> obtenerUnProductoAsNotTracking(int id)
        {
            return await _context.clsProducto.Where(a => a.id == id).AsNoTracking().FirstOrDefaultAsync();
        }
        public async Task<clsInventario> obtenerUnInventarioAsNotTracking(int id)
        {
            return await _context.clsInventario.Where(a => a.id == id).AsNoTracking().FirstOrDefaultAsync();
        }
    }
}
