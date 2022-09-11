
using ProyectoBack.Application.Interfaces.v1;
using ProyectoBack.Core.Entities.v1;
using ProyectoBack.Infraestructure.Data;
using ProyectoBack.Infraestructure.Repository.v1;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppBack.Infraestructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(DBContext context)
        {
            _context = context;
        }
        //Contex
        private readonly DBContext _context;

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public void saveChanges()
        {
            _context.SaveChanges();
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }                      
        private readonly IRepository<clsUsuario, int> _clsUsuario;
        private readonly IRepository<clsProducto, int> _clsProducto;
        private readonly IRepository<clsInventario, int> _clsInventario;


        //Instancias automáticas
        public IRepository<clsProducto, int> clsProducto =>
            _clsProducto ?? new BaseRepository<clsProducto, int>(_context);

        public IRepository<clsInventario, int> clsInventario =>
            _clsInventario ?? new BaseRepository<clsInventario, int>(_context);

        public IRepository<clsUsuario, int> clsUsuario =>
            _clsUsuario ?? new BaseRepository<clsUsuario, int>(_context);
       

 
        //Repositorios manuales
        private readonly IServicioRepository _IServicioRepository;
        //Instancias manuales
        public IServicioRepository IServicioRepository =>
            _IServicioRepository ?? new ServicioRepository(_context);




    }
}
