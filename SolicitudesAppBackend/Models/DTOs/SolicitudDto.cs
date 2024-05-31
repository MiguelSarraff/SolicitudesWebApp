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
    public class SolicitudDto
    {
        public int Id { get; set; }

        public String Codigo { get; set; }

        [Required(ErrorMessage = "El tipo de solicitud es requerido")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "El codigo de la solicitud debe estar ente 1 y 100 caracteres")]
        public string SolicitudTipo { get; set; }

        [Required(ErrorMessage = "La descripción es requerida")]
        [StringLength(256, MinimumLength = 1, ErrorMessage = "La descripción de la solicitud debe estar ente 1 y 100 caracteres")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El estatus es requerido")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "El estatus de la solicitud debe estar ente 1 y 100 caracteres")]
        public string Estatus { get; set; }

        [StringLength(256, ErrorMessage = "La resolución de la solicitud es de 256 caracteres maximo")]
        public string Resolucion { get; set; }

        public int SeccionId { get; set; }

        public string NombreSeccion { get; set; }

        public string ProfesorSeccion{ get; set; }

        public string MateriaSeccion { get; set; }

        public int EstudianteId { get; set; }

        public string EstudianteNombre { get; set; }


    }
}
