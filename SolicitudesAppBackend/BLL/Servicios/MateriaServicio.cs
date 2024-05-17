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
    public class MateriaServicio : IMateriaServicio
    {
        private readonly IUnidadTrabajo _unidadTrabajo;
        private readonly IMapper _mapper;

        public MateriaServicio(IUnidadTrabajo unidadTrabajo, IMapper mapper)
        {
            _unidadTrabajo = unidadTrabajo;
            _mapper = mapper;
        }

        public async Task<MateriaDto> Agregar(MateriaDto modeloDto)
        {
            try
            {
                Materia materia = new Materia
                {
                    materiaNombre= modeloDto.materiaNombre,
                    materiaCodigo = modeloDto.materiaCodigo,
                    materiaCreditos = modeloDto.materiaCreditos,
                    CarreraId = modeloDto.CarreraId,
                    estado = modeloDto.estado == 1 ? true : false,
                    FechaCreacion = DateTime.Now,
                    FechaActualizacion = DateTime.Now,

                };
                await _unidadTrabajo.Materia.Agregar(materia);
                await _unidadTrabajo.Guardar();
                if (materia.Id == 0)
                    throw new TaskCanceledException("La materia no se pudo crear");
                return _mapper.Map<MateriaDto>(materia);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task Actualizar(MateriaDto modeloDto)
        {
            try
            {
                var materiaDb = await _unidadTrabajo.Materia.ObtenerPrimero(e => e.Id == modeloDto.Id);
                if (materiaDb == null)
                    throw new TaskCanceledException("La materia no existe");

                materiaDb.materiaNombre = modeloDto.materiaNombre;
                materiaDb.materiaCodigo = modeloDto.materiaCodigo;
                materiaDb.materiaCreditos = modeloDto.materiaCreditos;
                materiaDb.estado = modeloDto.estado == 1 ? true : false;
                _unidadTrabajo.Materia.Actualizar(materiaDb);
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
                var materiaDb = await _unidadTrabajo.Materia.ObtenerPrimero(e => e.Id == id);
                if (materiaDb == null)
                    throw new TaskCanceledException("La materia no existe");
                _unidadTrabajo.Materia.Remover(materiaDb);
                await _unidadTrabajo.Guardar();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<MateriaDto>> ObtenerTodos()
        {
            try
            {
                var lista = await _unidadTrabajo.Materia.ObtenerTodos(incluirPropiedades: "Carrera",
                                orderBy: e => e.OrderBy(e => e.materiaNombre));
                return _mapper.Map<IEnumerable<MateriaDto>>(lista);

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}


    

