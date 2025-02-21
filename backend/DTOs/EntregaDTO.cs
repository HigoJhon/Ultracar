using System.ComponentModel.DataAnnotations;

namespace backend.DTOs
{
    public class EntregaCreateDTO
    {
        [Required(ErrorMessage = "O OrçamentoId é obrigatório.")]
        public int OrcamentoId { get; set; }

        [Required(ErrorMessage = "O CEP é obrigatório.")]
        [RegularExpression(@"^\d{5}-\d{3}$", ErrorMessage = "CEP inválido. Use o formato 99999-999.")]
        public string? Cep { get; set; }
    }

    public class EnderecoViaCepDTO
    {
        public string? Cep { get; set; }
        public string? Logradouro { get; set; }
        public string? Bairro { get; set; }
        public string? Localidade { get; set; }
        public string? Uf { get; set; }
        public bool? Erro { get; set; }
    }
}