using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace backend.Dto
{
    public class OrcamentoCreateDTO
    {
        [Required(ErrorMessage = "O número do orçamento é obrigatório.")]
        public int Numero { get; set; }

        public string ?PlacaVeiculo { get; set; }

        [Required(ErrorMessage = "O nome do cliente é obrigatório.")]
        [StringLength(255, ErrorMessage = "O nome do cliente não pode ter mais de 255 caracteres.")]
        public string ?NomeCliente { get; set; }

        public List<PecaOrcamentoCreateDTO> Pecas { get; set; } = new();
    }

    public class OrcamentoUpdateDTO
    {
        public int Numero { get; set; }
        public string ?PlacaVeiculo { get; set; }
        public string ?NomeCliente { get; set; }
        public List<PecaOrcamentoUpdateDTO> Pecas { get; set; } = new();
    }
}