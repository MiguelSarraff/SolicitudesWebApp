using Models.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs
{
    public class MateriaDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "El nombre de la materia debe estar ente 1 y 100 caracteres")]
        public string MateriaNombre { get; set; }

        [Required(ErrorMessage = "El codigo es requerido")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "El codigo de la materia debe estar ente 1 y 100 caracteres")]
        public string MateriaCodigo { get; set; }

        [Required(ErrorMessage = "Los creditos son requeridos")]
        [StringLength(2, MinimumLength = 1, ErrorMessage = "Los creditos de la materia deben maximo 2 caracteres")]
        public string MateriaCreditos { get; set; }

        [Required(ErrorMessage = "La carrera es requerida")]
        public int CarreraId { get; set; }

        public string CarreraNombre { get; set; }

        public int Estado { get; set; }

    }
}
