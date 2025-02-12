using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class OrcamentoPecas
    {
        [Key]
        public int Id { get; set; }
        public int OrcamentoId { get; set; }
        public Orcamentos ?Orcamentos { get; set; }
        public int PecaId { get; set; }
        public Peca ?Peca { get; set; }
        public int Quantidade { get; set; }
        public EstadoPeca estadoPeca { get; set; } = EstadoPeca.EmEspera;
    }

    public enum EstadoPeca
    {
        EmEspera,
        LiberadaParaCompra,
        Entregue
    }
}