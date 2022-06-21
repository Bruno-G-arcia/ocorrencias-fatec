using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OcorrenciasWeb.Models
{
    public class Usuario: Pessoa
    {
        public int IdUsuario { get; set; }

        [Required(ErrorMessage ="Email é obrigatório")]
        [DataType(DataType.EmailAddress, ErrorMessage ="Email inválido")]
        [EmailAddress]
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public string? Tipo { get; set; }
    }
}