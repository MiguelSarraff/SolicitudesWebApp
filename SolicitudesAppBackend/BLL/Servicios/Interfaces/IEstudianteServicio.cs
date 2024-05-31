using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Servicios.Interfaces
{
    public interface IEstudianteServicio
    {
        Task<IEnumerable<EstudianteDto>> ObtenerTodos();

        Task<EstudianteDto> Agregar(EstudianteDto modeloDto);

        Task Actualizar(EstudianteDto modeloDto);

        Task Remover(int EstudianteId);
    }
}
