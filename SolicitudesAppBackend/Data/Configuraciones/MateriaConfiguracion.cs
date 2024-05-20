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
            builder.Property(x => x.MateriaNombre).IsRequired().HasMaxLength(100);
            builder.Property(x => x.MateriaCodigo).IsRequired().HasMaxLength(100);
            builder.Property(x => x.MateriaCreditos).IsRequired().HasMaxLength(2);
            builder.Property(x => x.Estado).IsRequired();
            builder.Property(x => x.CarreraId).IsRequired();

            /* Relaciones */

            builder.HasOne(x=> x.Carrera).WithMany()
                   .HasForeignKey(x => x.CarreraId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
