using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestBancoPichincha.Api.Movimientos.Modelo;

namespace TestBancoPichincha.Api.Movimientos.Aplicacion
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Movimiento, MovimientoDto>();
        }
    }
}
