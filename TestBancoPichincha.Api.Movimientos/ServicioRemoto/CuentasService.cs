using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using TestBancoPichincha.Api.Movimientos.InterfaceRemota;
using TestBancoPichincha.Api.Movimientos.ModeloRemoto;

namespace TestBancoPichincha.Api.Movimientos.ServicioRemoto
{
    public class CuentasService : ICuentasService
    {
        private readonly IHttpClientFactory _httpCliente;
        private readonly ILogger<CuentasService> _logger;

        public CuentasService(IHttpClientFactory httpCliente, ILogger<CuentasService> logger)
        {
            _httpCliente = httpCliente;
            _logger = logger;
        }
        public async Task<(bool resultado, CuentaRemoto Cuenta, string ErrorMessage)> GetCuenta(Guid? CuentaId)
        {
            try
            {
                var cliente = _httpCliente.CreateClient("Cuentas");
                var response = await cliente.GetAsync($"api/Cuentas/{CuentaId}");
                if (response.IsSuccessStatusCode)
                {
                    var contenido = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    var resultado = JsonSerializer.Deserialize<CuentaRemoto>(contenido, options);
                    return (true, resultado, null);
                }

                return (false, null, response.ReasonPhrase);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                return (false, null, e.Message);
            }
        }
    }
}
