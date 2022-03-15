using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestBancoPichincha.Api.Cliente.Modelo;

namespace TestBancoPichincha.Api.Cliente.Aplicacion
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ClienteBanco, ClienteDto>();
        }
    }
}
