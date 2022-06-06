using OcorrenciasWeb.Models;

namespace OcorrenciasWeb.Repositories
{
    public interface IOrdemServicoRepository
    {
      void Create(OrdemServico ordemServico); 
      List<OrdemServico> Read();
      OrdemServico Read(int id);
      void Update(int id, OrdemServico ordemServico);
      void Delete(int id); 
    }
}