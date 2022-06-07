using OcorrenciasWeb.Models;

namespace OcorrenciasWeb.Repositories
{
    public interface IFuncionarioRepository
    {
      void Create(Funcionario funcionario); 
      List<Funcionario> Read();
      Funcionario Read(int id);
      Funcionario ReadUsuario(int id);
      void Update(int id, Funcionario funcionario);
      void UpdateFuncionarioPessoa(int id, Funcionario funcionario);
      void Delete(int id); 
    }
}  