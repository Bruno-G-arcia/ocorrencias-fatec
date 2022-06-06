using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OcorrenciasWeb.Models;
using OcorrenciasWeb.Repositories;

namespace OcorrenciasWeb.Controllers
{
  public class HomeController : Controller
  {

    private readonly IUsuarioRepository UsuRep;
    public IClienteRepository ClRep;
    public IOcorrenciaRepository OcRep;
    public HomeController(IUsuarioRepository UsuRep)
    {
      this.UsuRep = UsuRep;
      this.ClRep = new ClienteRepository();
      this.OcRep = new OcorrenciaSQLRepository();
    }
    [Authorize]
    public IActionResult Cliente()
    {
      var idCliente = User.Claims.FirstOrDefault(c => c.Type == "idCliente").Value;

      List<Ocorrencia> ocorrencias = OcRep.ReadCliente(int.Parse(idCliente));
      return View(ocorrencias);

    }
    public IActionResult Funcionario()
    {
      return View();
    }
  }
}
