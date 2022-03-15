using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestBancoPichincha.Api.Cuenta.ModeloRemoto;

namespace TestBancoPichincha.Api.Cuenta.InterfaceRemota
{
    public interface IClientesService
    {
        Task<(bool resultado, ClienteRemoto Cliente, string ErrorMessage)> GetCliente(Guid? ClienteId);
    }
}
