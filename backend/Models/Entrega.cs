namespace backend.Models
{
    public class Entrega
    {
        public int Id { get; set; }
        public int OrcamentoId { get; set; }
        public string ?Cep { get; set; }
        public string ?Endereco { get; set; }

        public Orcamento ?Orcamento { get; set; }
    }
}