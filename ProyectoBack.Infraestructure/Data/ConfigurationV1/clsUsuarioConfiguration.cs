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
    class clsUsuarioConfiguration : IEntityTypeConfiguration<clsUsuario>
    {
        public void Configure(EntityTypeBuilder<clsUsuario> builder)
        {
            builder.ToTable("tblUsuario");

            builder.Property(e => e.id).HasColumnName("id");
            builder.Property(e => e.usuario).HasColumnName("usuario").IsRequired().HasMaxLength(50);
            builder.Property(e => e.password).HasColumnName("password").IsRequired();
            builder.Property(e => e.correo).HasColumnName("correo").IsRequired().HasMaxLength(100);            
            builder.Property(e => e.nombre).HasColumnName("nombre").IsRequired().HasMaxLength(50);
            builder.Property(e => e.apellido).HasColumnName("apellido").IsRequired().HasMaxLength(50);
            builder.Property(e => e.activo).HasColumnName("activo").IsRequired().HasDefaultValueSql("((1))");

            builder.Property(e => e.fechaCreacion).HasColumnName("fechaCreacion").HasColumnType("datetime2(7)");
            builder.Property(e => e.fechaModificacion).HasColumnName("fechaModificacion").HasColumnType("datetime2(7)");
            builder.Property(e => e.modificadoPor).HasColumnName("modificadoPor").HasMaxLength(50);
            builder.Property(e => e.creadoPor).HasColumnName("creadoPor").HasMaxLength(50);


        }
    }
}
