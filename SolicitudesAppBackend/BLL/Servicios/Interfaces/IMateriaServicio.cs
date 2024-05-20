using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Servicios.Interfaces
{
    public interface IMateriaServicio
    {
        Task<IEnumerable<MateriaDto>> ObtenerTodos();

        Task<MateriaDto> Agregar(MateriaDto modeloDto);

        Task Actualizar(MateriaDto modeloDto);

        Task Remover(int id);
    }
}
