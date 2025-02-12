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
        public Peca Peca { get; set; }

        public int Quantidade { get; set; }  // Positivo (entrada) ou Negativo (saída)
        public string Tipo { get; set; }  // "Entrada" ou "Saída"
        public DateTime Data { get; set; }
    }

}