using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Servicios.Interfaces
{
    public interface ISeccionServicio
    {
        Task<IEnumerable<SeccionDto>> ObtenerTodos();

        Task<SeccionDto> Agregar(SeccionDto modeloDto);

        Task Actualizar(SeccionDto modeloDto);

        Task Remover(int SeccionId);
    }
}
