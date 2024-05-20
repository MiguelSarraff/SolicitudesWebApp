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
    public class CarreraServicio : ICarreraServicio
    {
        private readonly IUnidadTrabajo _unidadTrabajo;
        private readonly IMapper _mapper;

        public CarreraServicio(IUnidadTrabajo unidadTrabajo, IMapper mapper)
        {
            _unidadTrabajo = unidadTrabajo;
            _mapper = mapper;
        }

        public async Task<CarreraDto> Agregar(CarreraDto modeloDto)
        {
            try
            {
                Carrera carrera = new Carrera
                {
                    CarreraNombre = modeloDto.CarreraNombre,
                    CarreraCodigo = modeloDto.CarreraCodigo,
                    Estado = modeloDto.Estado == 1 ? true : false,
                    FechaCreacion = DateTime.Now,
                    FechaActualizacion = DateTime.Now,

                };
                await _unidadTrabajo.Carrera.Agregar(carrera);
                await _unidadTrabajo.Guardar();
                if (carrera.Id == 0)
                    throw new TaskCanceledException("La Carrera no se pudo crear");
                return _mapper.Map<CarreraDto>(carrera);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task Actualizar(CarreraDto modeloDto)
        {
            try
            {
                var CarreraDb = await _unidadTrabajo.Carrera.ObtenerPrimero(e => e.Id == modeloDto.Id);
                if (CarreraDb == null)
                    throw new TaskCanceledException("La carrera no existe");

                CarreraDb.CarreraNombre = modeloDto.CarreraNombre;
                CarreraDb.CarreraCodigo = modeloDto.CarreraCodigo;
                CarreraDb.Estado = modeloDto.Estado == 1 ? true : false;
                _unidadTrabajo.Carrera.Actualizar(CarreraDb);
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
                var CarreraDb = await _unidadTrabajo.Carrera.ObtenerPrimero(e => e.Id == id);
                if (CarreraDb == null)
                    throw new TaskCanceledException("La carrera no existe");
                _unidadTrabajo.Carrera.Remover(CarreraDb);
                await _unidadTrabajo.Guardar();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<CarreraDto>> ObtenerTodos()
        {
            try
            {
                var lista = await _unidadTrabajo.Carrera.ObtenerTodos(x => x.Estado == true,
                                orderBy: e => e.OrderBy(e => e.CarreraNombre));
                return _mapper.Map<IEnumerable<CarreraDto>>(lista);

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}


    

