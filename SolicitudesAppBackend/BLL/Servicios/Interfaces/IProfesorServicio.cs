using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Servicios.Interfaces
{
    public interface IProfesorServicio
    {
        Task<IEnumerable<ProfesorDto>> ObtenerTodos();

        Task<ProfesorDto> Agregar(ProfesorDto modeloDto);

        Task Actualizar(ProfesorDto modeloDto);

        Task Remover(int ProfesorId);
    }
}
