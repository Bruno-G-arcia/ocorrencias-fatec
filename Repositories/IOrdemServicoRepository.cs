using OcorrenciasWeb.Models;

namespace OcorrenciasWeb.Repositories
{
    public interface IOrdemServicoRepository
    {
      void Create(OrdemServico ordemServico); 
      List<OrdemServico> Read();
      public List<OrdemServico> ReadOc(int idOc);
      OrdemServico Read(int id);
      void Update(int id, OrdemServico ordemServico);
      
      void Delete(int id); 
    }
}