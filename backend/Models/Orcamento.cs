using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Orcamento
    {
        [Key]
        public int Id { get; set; }
        public int Numeracao { get; set; }
        public string PlacaVeiculo { get; set; }
        public string NomeCliente { get; set; }
        public DateTime DiaOrcamento { get; set; }
    }
}