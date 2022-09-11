using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using ProyectoBack.Core.Entities.v1;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBack.Infraestructure.Data.ConfigurationV1
{
    class clsInventarioConfiguration : IEntityTypeConfiguration<clsInventario>
    {
        public void Configure(EntityTypeBuilder<clsInventario> builder)
        {
            builder.ToTable("tblInventario");

            builder.Property(e => e.id).HasColumnName("id");
            
            builder.Property(e => e.cantidadEntrada).HasColumnName("cantidadEntrada").HasColumnType("int");
            builder.Property(e => e.idProducto).HasColumnName("idProducto").HasColumnType("int");
            builder.Property(e => e.codigo).HasColumnName("codigo").HasMaxLength(100);
            builder.Property(e => e.precio).HasColumnName("precio").HasColumnType("decimal");
            builder.Property(e => e.descripcion).HasColumnName("descripcion").HasMaxLength(200);
            builder.Property(e => e.cantidad).HasColumnName("cantidad").HasColumnType("int");
            builder.Property(e => e.documento).HasColumnName("documento").HasColumnType("VARBINARY(MAX)");
            builder.Property(e => e.nombreDocumento).HasColumnName("nombreDocumento");


            builder.Property(e => e.fechaCreacion).HasColumnName("fechaCreacion").HasColumnType("datetime2(7)");
            builder.Property(e => e.fechaModificacion).HasColumnName("fechaModificacion").HasColumnType("datetime2(7)");
            builder.Property(e => e.modificadoPor).HasColumnName("modificadoPor").HasMaxLength(50);
            builder.Property(e => e.creadoPor).HasColumnName("creadoPor").HasMaxLength(50);

            builder.HasOne(a => a.idProductoNavigation)
                .WithMany(e => e.clsInventarios)
                .HasForeignKey(a => a.idProducto)
                .HasConstraintName("fk_inventario_producto");

        }
    }
}
