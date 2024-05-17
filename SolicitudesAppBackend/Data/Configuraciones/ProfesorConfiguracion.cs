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
    public class ProfesorConfiguracion: IEntityTypeConfiguration<Profesor>
    {
        public void Configure(EntityTypeBuilder<Profesor> builder)
        {
            builder.Property(x => x.ProfesorId).IsRequired();
            builder.Property(x => x.ProfesorNombres).IsRequired().HasMaxLength(60);
            builder.Property(x => x.ProfesorApellidos).IsRequired().HasMaxLength(60);
            builder.Property(x => x.Cedula).IsRequired(false).HasMaxLength(20);
            builder.Property(x => x.Direccion).IsRequired(false).HasMaxLength(100);
            builder.Property(x => x.Telefono).IsRequired(false).HasMaxLength(20);
            builder.Property(x => x.Email).IsRequired(false).HasMaxLength(100);
            builder.Property(x => x.Genero).IsRequired().HasColumnType("char").HasMaxLength(1);
            builder.Property(x => x.FechaNacimiento).IsRequired();
            builder.Property(x => x.Estado).IsRequired();

            

        }
    }
}
