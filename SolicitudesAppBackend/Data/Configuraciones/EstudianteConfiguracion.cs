using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configuraciones
{
    public class EstudianteConfiguracion: IEntityTypeConfiguration<Estudiante>
    {
        public void Configure(EntityTypeBuilder<Estudiante> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.EstudianteNombres).IsRequired().HasMaxLength(60);
            builder.Property(x => x.EstudianteApellidos).IsRequired().HasMaxLength(60);
            builder.Property(x => x.UsuarioId).IsRequired();
            builder.Property(x => x.Cedula).IsRequired(false).HasMaxLength(20);
            builder.Property(x => x.Direccion).IsRequired(false).HasMaxLength(100);
            builder.Property(x => x.Telefono).IsRequired(false).HasMaxLength(20);
            builder.Property(x => x.Email).IsRequired(false).HasMaxLength(100);
            builder.Property(x => x.Genero).IsRequired().HasMaxLength(1);
            builder.Property(x => x.Estado).IsRequired();



            builder.HasOne(x => x.Usuario).WithMany()
                  .HasForeignKey(x => x.UsuarioId)
                  .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
