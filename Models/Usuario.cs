namespace OcorrenciasWeb.Models
{
    public class Usuario: Pessoa
    {
        public int IdUsuario { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public string? Tipo { get; set; }
    }
}