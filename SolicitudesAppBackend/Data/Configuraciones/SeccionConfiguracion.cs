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
    public class SeccionConfiguracion: IEntityTypeConfiguration<Seccion>
    {
        public void Configure(EntityTypeBuilder<Seccion> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Codigo).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Edificio).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Aula).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Horario).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Estado).IsRequired();
            builder.Property(x => x.MateriaId).IsRequired();
            builder.Property(x => x.ProfesorId).IsRequired();


            /* Relaciones */

            builder.HasOne(x => x.Materia).WithMany()
                   .HasForeignKey(x => x.MateriaId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x=>x.Profesor).WithMany()
                   .HasForeignKey(x =>x.ProfesorId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
