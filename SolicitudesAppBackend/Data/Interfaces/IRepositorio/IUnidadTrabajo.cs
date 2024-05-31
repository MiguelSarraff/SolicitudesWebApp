using Data.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces.IRepositorio
{
    public interface IUnidadTrabajo : IDisposable
    {
        ICarreraRepositorio Carrera { get; }

        IMateriaRepositorio Materia { get; }

        IProfesorRepositorio Profesor { get; }

        IEstudianteRepositorio Estudiante { get; }

        ISeccionRepositorio Seccion { get; }

        ISolicitudRepositorio Solicitud { get; }

        Task Guardar();
    }
}
