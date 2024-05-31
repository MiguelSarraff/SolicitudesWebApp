using AutoMapper;
using BLL.Servicios.Interfaces;
using Data.Interfaces.IRepositorio;
using Models.Entidades;
using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Servicios
{
    public class EstudianteServicio : IEstudianteServicio
    {
        private readonly IUnidadTrabajo _unidadTrabajo;
        private readonly IMapper _mapper;

        public EstudianteServicio(IUnidadTrabajo unidadTrabajo, IMapper mapper)
        {
            _unidadTrabajo = unidadTrabajo;
            _mapper = mapper;
        }

        public async Task<EstudianteDto> Agregar(EstudianteDto modeloDto)
        {
            try
            {
                Estudiante estudiante = new Estudiante
                {
                    EstudianteNombres = modeloDto.EstudianteNombres,
                    EstudianteApellidos = modeloDto.EstudianteApellidos,
                    Cedula = modeloDto.Cedula,
                    Direccion = modeloDto.Direccion,
                    Telefono = modeloDto.Telefono,
                    Email = modeloDto.Email,
                    Genero = modeloDto.Genero,
                    Estado = modeloDto.Estado == 1? true: false,
                    UsuarioId = modeloDto.UsuarioId,
                    FechaCreacion = DateTime.Now,
                    FechaActualizacion = DateTime.Now,

                };
                await _unidadTrabajo.Estudiante.Agregar(estudiante);
                await _unidadTrabajo.Guardar();
                if (estudiante.Id == 0)
                    throw new TaskCanceledException("El Estudiante no se pudo crear");
                return _mapper.Map<EstudianteDto>(estudiante);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task Actualizar(EstudianteDto modeloDto)
        {
            try
            {
                var EstudianteDb = await _unidadTrabajo.Estudiante.ObtenerPrimero(e => e.Id == modeloDto.Id);
                if (EstudianteDb == null)
                    throw new TaskCanceledException("El Estudiante no existe");

                EstudianteDb.EstudianteNombres = modeloDto.EstudianteNombres;
                EstudianteDb.EstudianteApellidos = modeloDto.EstudianteApellidos;
                EstudianteDb.Cedula = modeloDto.Cedula;
                EstudianteDb.Direccion = modeloDto.Direccion;
                EstudianteDb.Telefono = modeloDto.Telefono;
                EstudianteDb.Email = modeloDto.Email;
                EstudianteDb.Genero = modeloDto.Genero;
                EstudianteDb.UsuarioId = modeloDto.UsuarioId;
                EstudianteDb.Estado = modeloDto.Estado == 1 ? true : false;
                _unidadTrabajo.Estudiante.Actualizar(EstudianteDb);
                await _unidadTrabajo.Guardar();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task Remover(int Id)
        {
            try
            {
                var EstudianteDb = await _unidadTrabajo.Estudiante.ObtenerPrimero(e => e.Id == Id);
                if (EstudianteDb == null)
                    throw new TaskCanceledException("El Estudiante no existe");
                _unidadTrabajo.Estudiante.Remover(EstudianteDb);
                await _unidadTrabajo.Guardar();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<EstudianteDto>> ObtenerTodos()
        {
            try
            {
                var lista = await _unidadTrabajo.Estudiante.ObtenerTodos(incluirPropiedades: "Usuario",
                                orderBy: e => e.OrderBy(e => e.EstudianteNombres)) ;
                return _mapper.Map<IEnumerable<EstudianteDto>>(lista);

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}


    

