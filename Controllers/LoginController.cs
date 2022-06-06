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
    public LoginController(IUsuarioRepository UsuRep)
    {
      this.UsuRep = UsuRep;
      this.ClRep = new ClienteRepository();
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
      TempData["Error"] = "Invalid Username or Password";
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
