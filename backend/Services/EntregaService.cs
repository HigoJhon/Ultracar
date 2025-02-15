using backend.Models;
using Newtonsoft.Json;

namespace backend.Services
{
    public class EntregaService : IEntregaService
    {
        private readonly HttpClient _httpClient;

        public EntregaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Entrega> ObterEnderecoPorCep(string cep)
        {
            var url = $"https://viacep.com.br/ws/{cep}/json/";

            var response = await _httpClient.GetStringAsync(url);
            var endereco = JsonConvert.DeserializeObject<Entrega>(response);

            return endereco;
        }
    }
}
