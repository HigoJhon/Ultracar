using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace backend.Models
{
    public class OrcamentoPecas
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Orcamento")]
        public int OrcamentoId { get; set; }
        [ForeignKey("Peca")]
        public int PecaId { get; set; }
        public int Quantidade { get; set; }

        public EstadoPeca Estado { get; set; }
        [JsonIgnore]
        public Orcamento ?Orcamento { get; set; }
        public Peca ?Peca { get; set; }
    }

    public enum EstadoPeca
    {
        EmEspera,
        LiberadoParaCompra,
        Entregue
    }
}