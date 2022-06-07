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

      var cliente = ClRep.Read(Int32.Parse(idCliente));
      
      ViewBag.ClNome = cliente.Nome;

      List<Ocorrencia> ocorrencias = OcRep.ReadCliente(int.Parse(idCliente));
      return View(ocorrencias);

    }

    [Authorize]
    public IActionResult Funcionario()
    {
      List<Ocorrencia> ocorrencias = OcRep.Read();
      return View(ocorrencias);
    }

    [Authorize]
    public IActionResult Main()
    {
     
      if(User.IsInRole("Cliente")){
        return RedirectToAction("Cliente", "Home");
      }
      else{
        return RedirectToAction("Funcionario", "Home");
      }

    }
    
  }
}
