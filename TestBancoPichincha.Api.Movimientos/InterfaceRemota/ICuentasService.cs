using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestBancoPichincha.Api.Movimientos.ModeloRemoto;

namespace TestBancoPichincha.Api.Movimientos.InterfaceRemota
{
    public interface ICuentasService
    {
        Task<(bool resultado, CuentaRemoto Cuenta, string ErrorMessage)> GetCuenta(Guid? CuentaId);

    }
}
