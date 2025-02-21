using System.ComponentModel.DataAnnotations;

namespace backend.Dto
{
    public class PecaCreateDTO
{
    [Required(ErrorMessage = "O nome da peça é obrigatório.")]
    [StringLength(255, ErrorMessage = "O nome da peça não pode ter mais de 255 caracteres.")]
    public string ?Nome { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "O estoque não pode ser negativo.")]
    public int Estoque { get; set; }

    [Range(0, double.MaxValue, ErrorMessage = "O preço não pode ser negativo.")]
    public decimal Preco { get; set; }
}

public class PecaUpdateDTO
{
    public string ?Nome { get; set; }
    public int? Estoque { get; set; } 
    public decimal? Preco { get; set; } 
}
}