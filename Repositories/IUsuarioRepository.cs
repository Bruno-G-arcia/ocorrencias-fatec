using OcorrenciasWeb.Models;

namespace OcorrenciasWeb.Repositories
{
    public interface IUsuarioRepository
    {
      void Create(Usuario usuario); 
      List<Usuario> Read();
      Usuario Read(int id);
      Usuario Auth(string email, string senha);
      void Update(int id, Usuario usuario);
      void Delete(int id); 
    }
}