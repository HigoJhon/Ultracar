using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class OrcamentoPecas
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Orcamento")]
        public int OrcamentoId { get; set; }
        public Orcamento Orcamento { get; set; }

        [ForeignKey("Peca")]
        public int PecaId { get; set; }
        public Peca Peca { get; set; }

        public int Quantidade { get; set; }
        public string Status { get; set; }
        public decimal PrecoUnitario { get; set; }
    }
}