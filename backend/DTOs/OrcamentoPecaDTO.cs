namespace backend.Dto
{
    public class OrcamentoPecaDTO
    {
        public int OrcamentoId { get; set; }
        public int PecaId { get; set; }
        public int Quantidade { get; set; }
        public string ?Estado { get; set; }
    }
}
