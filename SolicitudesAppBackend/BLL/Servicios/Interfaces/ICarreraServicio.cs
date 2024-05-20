using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Servicios.Interfaces
{
    public interface ICarreraServicio
    {
        Task<IEnumerable<CarreraDto>> ObtenerTodos();

        Task<CarreraDto> Agregar(CarreraDto modeloDto);

        Task Actualizar(CarreraDto modeloDto);

        Task Remover(int id);
    }
}
