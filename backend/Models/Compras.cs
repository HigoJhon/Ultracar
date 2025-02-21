using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class Compras
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Peca")]
        public int PecaId { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoCusto { get; set; }
        public DateTime DataCompra { get; set; }

        public Peca ?Peca { get; set; }
    }
}