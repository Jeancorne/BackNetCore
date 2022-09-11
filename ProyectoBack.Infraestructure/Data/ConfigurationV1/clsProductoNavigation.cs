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
    class clsProductoNavigation : IEntityTypeConfiguration<clsProducto>
    {
        public void Configure(EntityTypeBuilder<clsProducto> builder)
        {
            builder.ToTable("tblProducto");

            builder.Property(e => e.id).HasColumnName("id");
            builder.Property(e => e.nombre).HasColumnName("nombre").HasMaxLength(100);
            builder.Property(e => e.cantidadMinAlerta).HasColumnName("cantidadMinAlerta").HasColumnType("int");


            builder.Property(e => e.fechaCreacion).HasColumnName("fechaCreacion").HasColumnType("datetime2(7)");
            builder.Property(e => e.fechaModificacion).HasColumnName("fechaModificacion").HasColumnType("datetime2(7)");
            builder.Property(e => e.modificadoPor).HasColumnName("modificadoPor").HasMaxLength(50);
            builder.Property(e => e.creadoPor).HasColumnName("creadoPor").HasMaxLength(50);
        }
    }
}
