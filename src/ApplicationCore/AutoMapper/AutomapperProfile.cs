using AutoMapper;
using GerFin.ApplicationCore.Entity;
using GerFin.ApplicationCore.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerFin.ApplicationCore.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Receita, ReceitaDTO>().ReverseMap();
        }
    }
}
