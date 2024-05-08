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
        }

    }
}
