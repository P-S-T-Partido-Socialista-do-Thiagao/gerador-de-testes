using GeradorDeTestes.Dominio.ModuloDisciplina;
using GeradorDeTestes.Infraestrutura.Orm.ModuloDisciplina;

namespace GeradorDeTestes.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped<IRepositorioDisciplina, RepositorioDisciplinaEmOrm>();

            builder.Services.AddEntityFrameworkConfig(builder.Configuration);
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            app.UseAntiforgery();
            app.UseStaticFiles();
            app.UseRouting();
            app.MapDefaultControllerRoute();

            app.Run();
        }
    }
}
