using backend.DTOs;
using backend.Models;
using backend.Repository;
using Newtonsoft.Json;


namespace backend.Services
{
    public class EntregaService : IEntregaService
    {
        private readonly HttpClient _httpClient;
        private readonly IEntregaRepository _repository;

        public EntregaService(HttpClient httpClient, IEntregaRepository repository)
        {
            _httpClient = httpClient;
            _repository = repository;
        }

        public async Task<Entrega?> ObterEnderecoPorCep(string cep)
        {
            var url = $"https://viacep.com.br/ws/{cep}/json/";

            try
            {
                var response = await _httpClient.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Erro ao obter endereço por CEP");
                    return null;
                }

                var responseContent = await response.Content.ReadAsStringAsync();

                var enderecoViaCep = JsonConvert.DeserializeObject<EnderecoViaCepDTO>(responseContent);

                if (enderecoViaCep != null && enderecoViaCep.Erro != true)
                {
                    var entrega = new Entrega 
                    {
                        Cep = enderecoViaCep.Cep,
                        Endereco = $"{enderecoViaCep.Logradouro}, {enderecoViaCep.Bairro}, {enderecoViaCep.Localidade} - {enderecoViaCep.Uf}"
                    };
                    return entrega;
                }
                else
                {
                    return null; 
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}