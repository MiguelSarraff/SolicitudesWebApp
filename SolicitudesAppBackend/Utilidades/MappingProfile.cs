using AutoMapper;
using Models.Entidades;
using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilidades
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Carrera,CarreraDto>()
                .ForMember(d => d.Estado, m=> m.MapFrom(o => o.Estado == true ? 1 :0));

            CreateMap<Materia,MateriaDto>()
                .ForMember(d => d.Estado, m => m.MapFrom(o => o.Estado == true ? 1 : 0))
                .ForMember(d => d.CarreraNombre, m => m.MapFrom(o =>o.Carrera.CarreraNombre));

            CreateMap<Profesor, ProfesorDto>()
                .ForMember(d => d.Estado, m => m.MapFrom(o => o.Estado == true ? 1 : 0));

            CreateMap<Seccion, SeccionDto>()
                .ForMember(d => d.Estado, m => m.MapFrom(o => o.Estado == true ? 1 : 0))
                .ForMember(d => d.NombreMateria, m => m.MapFrom(o => o.Materia.MateriaNombre))
                .ForMember(d => d.NombreProfesor, m => m.MapFrom(o => o.Profesor.ProfesorNombres));

            CreateMap<Estudiante, EstudianteDto>()
               .ForMember(d => d.Estado, m => m.MapFrom(o => o.Estado == true ? 1 : 0))
               .ForMember(d => d.NombreUsuario, m => m.MapFrom(o => o.Usuario.Username));

            CreateMap<Solicitud, SolicitudDto>()
               .ForMember(d => d.NombreSeccion, m => m.MapFrom(o => o.Seccion.Codigo))
               .ForMember(d => d.ProfesorSeccion, m => m.MapFrom(o => o.Seccion.Profesor))
               .ForMember(d => d.MateriaSeccion, m => m.MapFrom(o => o.Seccion.Materia))
               .ForMember(d => d.EstudianteNombre, m => m.MapFrom(o => o.Estudiante.Usuario));
               




        }

    }
}
