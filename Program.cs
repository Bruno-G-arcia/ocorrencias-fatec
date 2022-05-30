using OcorrenciasWeb.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace OcorrenciasWeb{
    public class Program{
        public static void Main(string[] args){

            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddTransient<IOcorrenciaRepository, OcorrenciaSQLRepository>();
            builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            builder.Services.AddControllersWithViews();
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/login";
                    options.AccessDeniedPath = "/";
                });

            var app = builder.Build();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Login}/{action=Login}/{id?}");
            app.Run();
        }
    }
}
