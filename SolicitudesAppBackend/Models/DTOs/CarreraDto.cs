using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs
{
    public class CarreraDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="El nombre es requerido")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "El nombre de la carrera debe estar ente 1 y 100 caracteres")]
        public string CarreraNombre { get; set; }

        [Required(ErrorMessage ="El codigo es reuqerido")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "El codigo de la carrera debe estar ente 1 y 100 caracteres")]
        public string CarreraCodigo { get; set; }

        [Required(ErrorMessage ="El estado es requerido")]
        public int Estado { get; set; } // 1-0
    }
}
