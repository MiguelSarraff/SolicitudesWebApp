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
    public class SolicitudConfiguracion: IEntityTypeConfiguration<Solicitud>
    {
        public void Configure(EntityTypeBuilder<Solicitud> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Codigo).IsRequired().HasMaxLength(11);
            builder.Property(x => x.SolicitudTipo).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Descripcion).IsRequired().HasMaxLength(256);
            builder.Property(x => x.Estatus).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Resolucion).IsRequired(false);
            builder.Property(x => x.SeccionId).IsRequired();
            builder.Property(x => x.EstudianteId).IsRequired();


            /* Relaciones */

            builder.HasOne(x => x.Seccion).WithMany()
                   .HasForeignKey(x => x.SeccionId)
                   .OnDelete(DeleteBehavior.NoAction);


            /* Estudiante */

            builder.HasOne(x=>x.Estudiante).WithMany()
                   .HasForeignKey(x =>x.EstudianteId)
                   .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
