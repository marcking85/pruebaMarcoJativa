using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TestBancoPichincha.Api.Cuenta.Aplicacion;
using TestBancoPichincha.Api.Cuenta.Modelo;

namespace TestBancoPichincha.Api.Test
{
    public class MappingTest : Profile
    {
        public MappingTest()
        {
            CreateMap<CuentaBanco, CuentaDto>();
        }
    }
}
