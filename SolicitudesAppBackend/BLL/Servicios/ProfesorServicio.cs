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
    public class ProfesorServicio : IProfesorServicio
    {
        private readonly IUnidadTrabajo _unidadTrabajo;
        private readonly IMapper _mapper;

        public ProfesorServicio(IUnidadTrabajo unidadTrabajo, IMapper mapper)
        {
            _unidadTrabajo = unidadTrabajo;
            _mapper = mapper;
        }

        public async Task<ProfesorDto> Agregar(ProfesorDto modeloDto)
        {
            try
            {
                Profesor profesor = new Profesor
                {
                    ProfesorNombres = modeloDto.ProfesorNombres,
                    ProfesorApellidos = modeloDto.ProfesorApellidos,
                    Cedula = modeloDto.Cedula,
                    Direccion = modeloDto.Direccion,
                    Telefono = modeloDto.Telefono,
                    Email = modeloDto.Email,
                    Genero = modeloDto.Genero,
                    FechaNacimiento = modeloDto.FechaNacimiento,
                    Estado = modeloDto.Estado == 1? true: false,
                    FechaCreacion = DateTime.Now,
                    FechaActualizacion = DateTime.Now,

                };
                await _unidadTrabajo.Profesor.Agregar(profesor);
                await _unidadTrabajo.Guardar();
                if (profesor.ProfesorId == 0)
                    throw new TaskCanceledException("El Profesor no se pudo crear");
                return _mapper.Map<ProfesorDto>(profesor);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task Actualizar(ProfesorDto modeloDto)
        {
            try
            {
                var ProfesorDb = await _unidadTrabajo.Profesor.ObtenerPrimero(e => e.ProfesorId == modeloDto.ProfesorId);
                if (ProfesorDb == null)
                    throw new TaskCanceledException("El Profesor no existe");

                ProfesorDb.ProfesorNombres = modeloDto.ProfesorNombres;
                ProfesorDb.ProfesorApellidos = modeloDto.ProfesorApellidos;
                ProfesorDb.Cedula = modeloDto.Cedula;
                ProfesorDb.Direccion = modeloDto.Direccion;
                ProfesorDb.Telefono = modeloDto.Telefono;
                ProfesorDb.Email = modeloDto.Email;
                ProfesorDb.Genero = modeloDto.Genero;
                ProfesorDb.FechaNacimiento = modeloDto.FechaNacimiento;
                ProfesorDb.Estado = modeloDto.Estado == 1 ? true : false;
                _unidadTrabajo.Profesor.Actualizar(ProfesorDb);
                await _unidadTrabajo.Guardar();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task Remover(int ProfesorId)
        {
            try
            {
                var ProfesorDb = await _unidadTrabajo.Profesor.ObtenerPrimero(e => e.ProfesorId == ProfesorId);
                if (ProfesorDb == null)
                    throw new TaskCanceledException("El Profesor no existe");
                _unidadTrabajo.Profesor.Remover(ProfesorDb);
                await _unidadTrabajo.Guardar();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<ProfesorDto>> ObtenerTodos()
        {
            try
            {
                var lista = await _unidadTrabajo.Profesor.ObtenerTodos(x => x.Estado == true,
                                orderBy: e => e.OrderBy(e => e.ProfesorNombres));
                return _mapper.Map<IEnumerable<ProfesorDto>>(lista);

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}


    

