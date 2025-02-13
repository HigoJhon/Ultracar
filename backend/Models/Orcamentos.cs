using System.ComponentModel.DataAnnotations;

namespace backend.Models 
{
    public class Orcamento
    {
        [Key]
        public int Id { get; set; }
        public string ?Numero { get; set; }
        public string ?Placa { get; set; }
        public string ?NameCliente { get; set; }

        public List<OrcamentoPecas> Pecas { get; set; } = new();
    }
}