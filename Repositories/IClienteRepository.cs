using OcorrenciasWeb.Models;

namespace OcorrenciasWeb.Repositories
{
    public interface IClienteRepository
    {
      void Create(Cliente cliente); 
      List<Cliente> Read();
      Cliente Read(int id);
      Cliente ReadUsuario(int id);
      void Update(int id, Cliente cliente);
      void UpdateClientePessoa(int id, Cliente cliente);
      void Delete(int id); 
    }
}  