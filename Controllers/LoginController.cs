using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using OcorrenciasWeb.Repositories;

namespace OcorrenciasWeb.Controllers
{
  public class LoginController : Controller
  {
    private readonly IUsuarioRepository UsuRep;
    private readonly IOcorrenciaRepository OcRep;
    public LoginController(IUsuarioRepository repository, IOcorrenciaRepository oRepository)
    {
      this.repository = repository;
      this.oRepository = oRepository;
    }
    
    [HttpGet("login")]
    public IActionResult Login(string returnUrl)
    {
      ViewData["ReturnUrl"] = returnUrl;
      return View();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Validate(string email, string senha, string returnUrl)
    {
      ViewData["ReturnUrl"] = returnUrl;
      if(returnUrl == null)
      {
        returnUrl = "/ocorrencia/index";
      }

      var usuario = repository.Auth(email, senha);
            
      if (usuario != null)
      {
        if (usuario.Tipo == "Funcionario")
        {
          this.AuthFuncionario();
        }
        else
        {
          this.AuthCliente();
        }

        return Redirect(returnUrl);
      }
      TempData["Error"] = "Invalid Username or Password";
      return View("login");
    }

    [Authorize]
    public async Task<IActionResult> Logout()
    {
      await HttpContext.SignOutAsync();
      return RedirectToAction("Login", "Login");

    }

    public async void AuthCliente(Cliente cliente)
    {

    }

    public async void AuthFuncionario(Funcionario funcionario)
    {

    }


  }
}
