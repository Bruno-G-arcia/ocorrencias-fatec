using System.ComponentModel.DataAnnotations;

namespace OcorrenciasWeb.Models
{
    public class Cliente : Usuario
    {
        [Required]
        public string Nome {get; set;}
        public int IdCliente { get; set; }
    }
}     