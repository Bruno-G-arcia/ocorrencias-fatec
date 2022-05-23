using OcorrenciasWeb.Models;

namespace OcorrenciasWeb.Repositories
{
    public interface IOcorrenciaRepository
    {
      void Create(Ocorrencia ocorrencia); 
      List<Ocorrencia> Read();
      Ocorrencia Read(int id);
      void Update(int id, Ocorrencia ocorrencia);
      void Delete(int id); 
    }
}