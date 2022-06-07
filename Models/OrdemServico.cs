namespace OcorrenciasWeb.Models
{
    public class OrdemServico
    {
        public int IdOrdemServico{ get; set; }
        public int IdOcorrencia{ get; set; }
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }
        public DateTime Abertura { get; set; }
        public string? Status { get; set;}
        public int IdFuncionario {get; set;}
    }
}