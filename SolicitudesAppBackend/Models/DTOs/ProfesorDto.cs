using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs
{
    public class ProfesorDto
    {
        
        public int ProfesorId { get; set; }

        [Required(ErrorMessage = "Nombre es requerido")]
        [StringLength(60, MinimumLength = 1, ErrorMessage = "El Nombre del Profesor debe estar ente 1 y 60 caracteres")]
        public string ProfesorNombres { get; set; }

        [Required(ErrorMessage = "Apellido es requerido")]
        [StringLength(60, MinimumLength = 1, ErrorMessage = "El Apellido del profesor debe estar ente 1 y 60 caracteres")]
        public string ProfesorApellidos { get; set; }

        [StringLength(20, MinimumLength = 1, ErrorMessage = "La cedula del profesor debe ser maximo 11 caracteres")]
        public string Cedula { get; set; }

        [StringLength(100, MinimumLength = 1, ErrorMessage = "La Direccion del profesor debe estar ente 1 y 100 caracteres")]
        public string Direccion { get; set; }

        [StringLength(20, MinimumLength = 1, ErrorMessage = "El Numero del profesor debe estar ente 1 y 20 caracteres")]
        public string Telefono { get; set; }

        [StringLength(100, MinimumLength = 1, ErrorMessage = "El correo del profesor debe ser maximo 100 caracteres")]
        public string Email { get; set; }
        public char Genero { get; set; }
        public int Estado { get; set; }
        public DateTime FechaNacimiento { get; set; }
     
    }
}
