using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestBancoPichincha.Api.Cuenta.Modelo;

namespace TestBancoPichincha.Api.Cuenta.Aplicacion
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CuentaBanco, CuentaDto>();
        }
    }
}
