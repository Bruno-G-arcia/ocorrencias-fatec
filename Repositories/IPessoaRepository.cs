using OcorrenciasWeb.Models;

namespace OcorrenciasWeb.Repositories
{
    public interface IPessoaRepository
    {
      void Create(Pessoa pessoa); 
      List<Pessoa> Read();
      Pessoa Read(int id);
      void Update(int id, Pessoa pessoa);
      void Delete(int id); 
    }
}  