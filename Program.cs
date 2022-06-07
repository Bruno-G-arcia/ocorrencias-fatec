using OcorrenciasWeb.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace OcorrenciasWeb{
    public class Program{
        public static void Main(string[] args){

            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddTransient<IOcorrenciaRepository, OcorrenciaSQLRepository>();
            builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            builder.Services.AddTransient<IClienteRepository, ClienteRepository>();
            builder.Services.AddTransient<IFuncionarioRepository, FuncionarioRepository>();
            builder.Services.AddTransient<IOrdemServicoRepository, OrdemServicoRepository>();


            builder.Services.AddControllersWithViews();
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/login";
                    options.AccessDeniedPath = "/";
                });
            builder.Services.Configure<IdentityOptions>(options =>
                options.ClaimsIdentity.UserIdClaimType = ClaimTypes.NameIdentifier);

            var app = builder.Build();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Login}/{action=Logout}/{id?}");
            app.Run();
        }
    }
}
