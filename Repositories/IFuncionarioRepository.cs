using OcorrenciasWeb.Models;

namespace OcorrenciasWeb.Repositories
{
    public interface IFuncionarioRepository
    {
      void Create(Funcionario funcionario); 
      List<Funcionario> Read();
      Funcionario Read(int id);
      void Update(int id, Funcionario funcionario);
      void Delete(int id); 
    }
}  