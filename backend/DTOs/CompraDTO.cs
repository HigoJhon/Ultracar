namespace backend.Dto
{
    public class CompraDTO
    {
        public int PecaId { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoCusto { get; set; }
        public DateTime DataCompra { get; set; }
    }
}
