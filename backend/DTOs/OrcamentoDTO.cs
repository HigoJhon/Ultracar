namespace backend.Dto
{
    public class OrcamentoDTO
    {
        public string Numero { get; set; }
        public string PlacaVeiculo { get; set; }
        public string NomeCliente { get; set; }
        public List<PecaDTO> Pecas { get; set; }
        }
}