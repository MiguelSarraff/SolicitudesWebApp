using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Models.Entidades
{
    public class Carrera
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength =1,ErrorMessage = "El nombre de la carrera debe estar ente 1 y 100 caracteres")]
        public string CarreraNombre  { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "El codigo de la carrera debe estar ente 1 y 100 caracteres")]
        public string CarreraCodigo { get; set; }

        [Required]
        public bool Estado { get; set; }

        public DateTime FechaCreacion { get; set; }

        public DateTime FechaActualizacion { get; set; }
    }
}
