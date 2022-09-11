
using ProyectoBack.Core.Entities.v1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBack.Application.Interfaces.v1
{
    public interface IUnitOfWork : IDisposable
    {
        void saveChanges();
        Task SaveChangesAsync();
                
        IRepository<clsUsuario, int> clsUsuario { get; }
        IRepository<clsProducto, int> clsProducto { get; }
        IRepository<clsInventario, int> clsInventario { get; }
        //Repositorios manuales
        IServicioRepository IServicioRepository { get; }


    }
}
