using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OcorrenciasWeb.Models
{
    public class Pessoa 
    {
        public int     IdPessoa { get; set; }

        [Required(ErrorMessage ="Campo Nome é obrigatório")]
        public string Nome     { get; set; }
        public string? Cpf      { get; set; }
        public string? Telefone { get; set; }
    }
} 