 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs
{
    public class RegistroDto
    {
        [Required(ErrorMessage ="Username es requerido")]
        public String Username { get; set; }

        [Required(ErrorMessage = "Password es requerido")]
        [StringLength(20,MinimumLength =7, ErrorMessage = "El password de contener al menos 7 caracteres")]
        public String Password { get; set; }

    }
}
