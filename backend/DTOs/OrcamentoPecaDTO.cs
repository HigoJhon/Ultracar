using System.ComponentModel.DataAnnotations;
using backend.Models;

namespace backend.Dto
{
    public class PecaOrcamentoCreateDTO
    {
        public int OrcamentoId { get; set; }
        public int PecaId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "A quantidade deve ser maior que zero.")]
        public int Quantidade { get; set; }
    }

    public class PecaOrcamentoUpdateDTO
    {
        public int OrcamentoId { get; set; }
        public int PecaId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "A quantidade deve ser maior que zero.")]
        public int Quantidade { get; set; }

        public EstadoPeca Estado { get; set; }
    }
}
