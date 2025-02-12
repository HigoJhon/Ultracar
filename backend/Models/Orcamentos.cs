using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Orcamentos
    {
        [Key]
        public int Id { get; set; }
        public int Numeracao { get; set; }
        public string ?PlacaVeiculo { get; set; }
        public string ?NomeCliente { get; set; }
        public DateTime DiaOrcamento { get; set; }
        public List<OrcamentoPecas> OrcamentoPecas { get; set; } = new();
    }
}