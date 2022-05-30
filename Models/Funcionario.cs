namespace OcorrenciasWeb.Models
{
    public class Funcionario: Usuario
    {
        public int      IdFuncionario { get; set; }
        public string?  Cargo         { get; set; }
    }
} 