using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Servicios.Interfaces
{
    public interface ISolicitudServicio
    {
        Task<IEnumerable<SolicitudDto>> ObtenerTodos();

        Task<SolicitudDto> Agregar(SolicitudDto modeloDto);

        Task Actualizar(SolicitudDto modeloDto);

        Task Remover(int id);
    }
}
