using System.ComponentModel.DataAnnotations;

namespace OcorrenciasWeb.Models
{
    public class Ocorrencia
    {
        public int IdOcorrencia { get; set; }
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }
        [DataType(DataType.Date)]
        public DateTime Abertura { get; set; }
        [DataType(DataType.Date)]
        public DateTime Prazo { get; set; }
        public string? Status { get; set;}
        public string? Prioridade { get; set; }
        public int IdCliente {get; set;}
        public string? NomeCliente {get; set;}
    }
}