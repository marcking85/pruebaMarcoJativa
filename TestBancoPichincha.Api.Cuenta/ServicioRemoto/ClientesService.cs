








using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using TestBancoPichincha.Api.Cuenta.InterfaceRemota;
using TestBancoPichincha.Api.Cuenta.ModeloRemoto;

namespace TestBancoPichincha.Api.Cuenta.ServicioRemoto
{
    public class ClientesService : IClientesService
    {
        private readonly IHttpClientFactory _httpCliente;
        private readonly ILogger<ClientesService> _logger;

        public ClientesService(IHttpClientFactory httpCliente, ILogger<ClientesService> logger)
        {
            _httpCliente = httpCliente;
            _logger = logger;
        }
        public async Task<(bool resultado, ClienteRemoto Cliente, string ErrorMessage)> GetCliente(Guid? ClienteId)
        {
            try
            {
                var cliente = _httpCliente.CreateClient("Clientes");
                var response = await cliente.GetAsync($"api/Clientes/{ClienteId}");
                if (response.IsSuccessStatusCode)
                {
                    var contenido = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    var resultado = JsonSerializer.Deserialize<ClienteRemoto>(contenido, options);
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
