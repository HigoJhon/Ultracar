using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class MovimentacaoEstoque
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Peca")]
        public int PecaId { get; set; }
        public int Quantidade { get; set; }
        public DateTime Data { get; set; }
        public string Tipo { get; set; }

        public Peca Peca { get; set; }
        public TipoMovimentacao tipoMovimentacao { get; set; }
    }

        public enum TipoMovimentacao
    {
        Entrada,
        Saida
    }

}