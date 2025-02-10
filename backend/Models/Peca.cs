using System.ComponentModel.DataAnnotations;

namespace backend.Models 
{
    public class Peca
    {
        [Key]
        public int Id { get; set; }
        public string ?Nome { get; set; }
        public int Estoque { get; set; }
        public decimal Preco { get; set; }
    }
}