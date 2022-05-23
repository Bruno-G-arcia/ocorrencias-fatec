using OcorrenciasWeb.Repositories;

namespace OcorrenciasWeb{
    public class Program{
        public static void Main(string[] args){

            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Services.AddTransient<IOcorrenciaRepository, OcorrenciaSQLRepository>();

            var app = builder.Build();
            app.MapDefaultControllerRoute();
            
            app.Run();


        }
    }
}
