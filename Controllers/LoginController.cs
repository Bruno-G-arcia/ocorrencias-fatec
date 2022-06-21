using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using OcorrenciasWeb.Repositories;

namespace OcorrenciasWeb.Controllers
{
  public class LoginController : Controller
  {
    private readonly IUsuarioRepository UsuRep;
    public IClienteRepository ClRep;
    public IFuncionarioRepository FnRep;
    public LoginController(IUsuarioRepository UsuRep)
    {
      this.UsuRep = UsuRep;
      this.ClRep = new ClienteRepository();
      this.FnRep = new FuncionarioRepository();
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

      var usuario = UsuRep.Auth(email, senha);
            
      if (usuario.Tipo == "Funcionario")
      {
        var funcionario = FnRep.ReadUsuario(usuario.IdUsuario);
        var cargo = "";
        if(funcionario.Cargo != null){
          cargo = funcionario.Cargo;
        }

        var claims = new List<Claim>();
        claims.Add(new Claim("idFuncionario", funcionario.IdFuncionario.ToString()));
        claims.Add(new Claim("Cargo", cargo));
        claims.Add(new Claim(ClaimTypes.Name, funcionario.Nome));
        claims.Add(new Claim(ClaimTypes.Role, usuario.Tipo));
        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
        await HttpContext.SignInAsync(claimsPrincipal);

        return RedirectToAction("Funcionario", "Home");
      }

      if (usuario.Tipo == "Cliente")
      {
        var cliente = ClRep.ReadUsuario(usuario.IdUsuario);
       
        var claims = new List<Claim>();
        claims.Add(new Claim("idCliente", cliente.IdCliente.ToString()));
        claims.Add(new Claim(ClaimTypes.Name, cliente.Nome));
        claims.Add(new Claim(ClaimTypes.Role, usuario.Tipo));
        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
        await HttpContext.SignInAsync(claimsPrincipal);

        return RedirectToAction("Cliente", "Home");
      }

      TempData["Error"] = "Email ou Senha incorretos";
      return View("login");
    }

    [Authorize]
    public async Task<IActionResult> Logout()
    {
      await HttpContext.SignOutAsync();
      return RedirectToAction("Login", "Login");

    }


  }
}
