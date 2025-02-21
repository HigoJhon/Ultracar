using System.ComponentModel.DataAnnotations;
using backend.Models;

namespace backend.Dto
{
    public class MovimentacaoEstoqueCreateDTO
    {
        /// <summary>
        /// ID da peça para a qual a movimentação está sendo registrada.
        /// </summary>
        public int PecaId { get; set; }

        /// <summary>
        /// Quantidade de itens movimentados (deve ser maior que zero).
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessage = "A quantidade deve ser maior que zero.")]
        public int Quantidade { get; set; }

        /// <summary>
        /// Tipo de movimentação (Entrada ou Saida).
        /// </summary>
        public TipoMovimentacao tipoMovimentacao { get; set; }
    }

    public class MovimentacaoEstoqueUpdateDTO
    {
        public int Id { get; set; }

        public int PecaId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "A quantidade deve ser maior que zero.")]
        public int Quantidade { get; set; }

        public TipoMovimentacao tipoMovimentacao { get; set; }
    }
}