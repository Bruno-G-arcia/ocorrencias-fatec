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

    private IFuncionarioRepository FnRep;
    public HomeController(IUsuarioRepository UsuRep)
    {
      this.UsuRep = UsuRep;
      this.ClRep = new ClienteRepository();
      this.OcRep = new OcorrenciaSQLRepository();
      this.FnRep = new FuncionarioRepository();
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

      var idFuncionario = User.Claims.FirstOrDefault(c => c.Type == "idFuncionario").Value;

      var funcionario = FnRep.Read(Int32.Parse(idFuncionario));
      
      ViewBag.FnNome = funcionario.Nome;
      ViewBag.FnCargo = funcionario.Cargo;

      List<Ocorrencia> ocorrencias = OcRep.Read();

      foreach(var oc in ocorrencias){
        var cliente = ClRep.Read(oc.IdCliente);
        oc.NomeCliente = cliente.Nome;
      }

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

    [Authorize]
    public IActionResult Denied()
    {
      return View();
    }
    
  }
}
