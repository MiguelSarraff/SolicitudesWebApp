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
    public class SeccionServicio : ISeccionServicio
    {
        private readonly IUnidadTrabajo _unidadTrabajo;
        private readonly IMapper _mapper;

        public SeccionServicio(IUnidadTrabajo unidadTrabajo, IMapper mapper)
        {
            _unidadTrabajo = unidadTrabajo;
            _mapper = mapper;
        }

        public async Task<SeccionDto> Agregar(SeccionDto modeloDto)
        {
            try
            {
                Seccion seccion = new Seccion
                {
                    Codigo = modeloDto.Codigo,
                    Edificio = modeloDto.Edificio,
                    Aula = modeloDto.Aula,
                    Horario = modeloDto.Horario,
                    MateriaId = modeloDto.MateriaId,
                    ProfesorId = modeloDto.ProfesorId,
                    Estado = modeloDto.Estado == 1 ? true : false,
                    FechaCreacion = DateTime.Now,
                    FechaActualizacion = DateTime.Now,

                };
                await _unidadTrabajo.Seccion.Agregar(seccion);
                await _unidadTrabajo.Guardar();
                if (seccion.Id == 0)
                    throw new TaskCanceledException("La Seccion no se pudo crear");
                return _mapper.Map<SeccionDto>(seccion);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task Actualizar(SeccionDto modeloDto)
        {
            try
            {
                var SeccionDb = await _unidadTrabajo.Seccion.ObtenerPrimero(e => e.Id == modeloDto.Id);
                if (SeccionDb == null)
                    throw new TaskCanceledException("La seccion no existe");

                SeccionDb.Codigo = modeloDto.Codigo;
                SeccionDb.Edificio = modeloDto.Edificio;
                SeccionDb.Aula = modeloDto.Aula;
                SeccionDb.Horario = modeloDto.Horario;
                SeccionDb.MateriaId = modeloDto.MateriaId;
                SeccionDb.ProfesorId = modeloDto.ProfesorId;
                SeccionDb.Estado = modeloDto.Estado == 1 ? true : false;
                _unidadTrabajo.Seccion.Actualizar(SeccionDb);
                await _unidadTrabajo.Guardar();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task Remover(int id)
        {
            try
            {
                var SeccionDb = await _unidadTrabajo.Seccion.ObtenerPrimero(e => e.Id == id);
                if (SeccionDb == null)
                    throw new TaskCanceledException("La Seccion no existe");
                _unidadTrabajo.Seccion.Remover(SeccionDb);
                await _unidadTrabajo.Guardar();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<SeccionDto>> ObtenerTodos()
        {
            try
            {
                var lista = await _unidadTrabajo.Seccion.ObtenerTodos(incluirPropiedades:"Materia,Profesor", 
                                orderBy: e => e.OrderBy(e => e.Codigo)) ;
                return _mapper.Map<IEnumerable<SeccionDto>>(lista);

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}


    

