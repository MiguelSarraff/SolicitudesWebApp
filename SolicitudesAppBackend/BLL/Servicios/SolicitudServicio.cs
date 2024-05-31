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
using System.Net.NetworkInformation;

namespace BLL.Servicios
{
    public class SolicitudServicio : ISolicitudServicio
    {
        private readonly IUnidadTrabajo _unidadTrabajo;
        private readonly IMapper _mapper;

        public SolicitudServicio(IUnidadTrabajo unidadTrabajo, IMapper mapper)
        {
            _unidadTrabajo = unidadTrabajo;
            _mapper = mapper;
        }

        public async Task<SolicitudDto> Agregar(SolicitudDto modeloDto)
        {
            try
            {
                Solicitud solicitud = new Solicitud
                {
                    Codigo = modeloDto.Codigo,
                    SolicitudTipo = modeloDto.SolicitudTipo,
                    Descripcion = modeloDto.Descripcion,
                    Estatus = modeloDto.Estatus,
                    Resolucion = modeloDto.Resolucion,
                    SeccionId = modeloDto.SeccionId,
                    EstudianteId = modeloDto.EstudianteId,
                   

                };
                await _unidadTrabajo.Solicitud.Agregar(solicitud);
                await _unidadTrabajo.Guardar();
                if (solicitud.Id == 0)
                    throw new TaskCanceledException("La solicitud no se pudo crear");
                return _mapper.Map<SolicitudDto>(solicitud);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task Actualizar(SolicitudDto modeloDto)
        {


            try
            {
                var SolicitudDb = await _unidadTrabajo.Solicitud.ObtenerPrimero(e => e.Id == modeloDto.Id);
                if (SolicitudDb == null)
                    throw new TaskCanceledException("La solicitud no existe");

                SolicitudDb.Codigo = modeloDto.Codigo;
                SolicitudDb.SolicitudTipo = modeloDto.SolicitudTipo;
                SolicitudDb.Descripcion = modeloDto.Descripcion;
                SolicitudDb.Estatus = modeloDto.Estatus;
                SolicitudDb.Resolucion = modeloDto.Resolucion;
                SolicitudDb.SeccionId = modeloDto.SeccionId;
                SolicitudDb.EstudianteId = modeloDto.EstudianteId;
                _unidadTrabajo.Solicitud.Actualizar(SolicitudDb);
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
                var SolicitudDb = await _unidadTrabajo.Solicitud.ObtenerPrimero(e => e.Id == id);
                if (SolicitudDb == null)
                    throw new TaskCanceledException("La Seccion no existe");
                _unidadTrabajo.Solicitud.Remover(SolicitudDb);
                await _unidadTrabajo.Guardar();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<SolicitudDto>> ObtenerTodos()
        {
            try
            {
                var lista = await _unidadTrabajo.Solicitud.ObtenerTodos(incluirPropiedades: "Seccion,Estudiante,Profesor,Materia", 
                                orderBy: e => e.OrderBy(e => e.Codigo)) ;
                return _mapper.Map<IEnumerable<SolicitudDto>>(lista);

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}


    

