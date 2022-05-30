namespace OcorrenciasWeb.Models
{
    public class OrdemServico
    {
        public int IdOcorrencia { get; set; }
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }
        public DateTime Abertura { get; set; }
        public DateTime Prazo { get; set; }
        public string? Status { get; set;}
        public string? Prioridade { get; set; }
        public int IdCliente {get; set;}
    }
}