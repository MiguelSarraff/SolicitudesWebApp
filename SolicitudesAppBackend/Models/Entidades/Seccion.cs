using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entidades
{
    public class Seccion
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El codigo es requerido")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "El codigo de la sesion debe estar ente 1 y 50 caracteres")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "El Edificio es requerido")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "El Edificio de la sesion debe estar ente 1 y 50 caracteres")]
        public string Edificio { get; set; }

        [Required(ErrorMessage = "El aula es requerida")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "El aula debe estar ente 1 y 50 caracteres")]
        public string Aula { get; set; }

        [Required(ErrorMessage = "El horario es requerido")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "El horario debe estar ente 1 y 100 caracteres")]
        public string Horario { get; set; }

        [Required(ErrorMessage = "La materia es requerida")]
        public int MateriaId { get; set; }

        [ForeignKey("MateriaId")]
        public Materia Materia { get; set; }

        [Required(ErrorMessage = "El profesor es requerido")]
        public int ProfesorId { get; set; }

        [ForeignKey("ProfesorId")]
        public Profesor Profesor { get; set; }
        
        public bool Estado { get; set; }

        public DateTime FechaCreacion { get; set; }

        public DateTime FechaActualizacion { get; set; }
    }
}
