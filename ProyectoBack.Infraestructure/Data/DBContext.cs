using Microsoft.EntityFrameworkCore;
using ProyectoBack.Core.Entities.v1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBack.Infraestructure.Data
{
    public partial class DBContext : DbContext
    {
        public DBContext()
        {
        }
        public DBContext(DbContextOptions<DBContext> options)
           : base(options)
        {
        }
        /// <summary>
        /// ///
        /// </summary>
        public virtual DbSet<clsUsuario> clsUsuario { get; set; }
        public virtual DbSet<clsProducto> clsProducto { get; set; }
        public virtual DbSet<clsInventario> clsInventario { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
