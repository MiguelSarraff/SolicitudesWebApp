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
    public class MateriaConfiguracion: IEntityTypeConfiguration<Materia>
    {
        public void Configure(EntityTypeBuilder<Materia> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.materiaNombre).IsRequired().HasMaxLength(100);
            builder.Property(x => x.materiaCodigo).IsRequired().HasMaxLength(100);
            builder.Property(x => x.materiaCreditos).IsRequired().HasMaxLength(100);
            builder.Property(x => x.CarreraId).IsRequired().HasMaxLength(100);
            builder.Property(x => x.estado).IsRequired();

            /* Relaciones */

            builder.HasOne(x=> x.Carrera).WithMany()
                   .HasForeignKey(x => x.CarreraId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
