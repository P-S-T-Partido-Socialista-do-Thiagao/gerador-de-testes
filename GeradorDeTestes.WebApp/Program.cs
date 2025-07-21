using GeradorDeTestes.Dominio.ModuloDisciplina;
using GeradorDeTestes.Dominio.ModuloMateria;
using GeradorDeTestes.Dominio.ModuloTeste;
using GeradorDeTestes.Infraestrutura.Orm.ModuloDisciplina;
using GeradorDeTestes.Infraestrutura.Orm.ModuloMateria;
using GeradorDeTestes.Infraestrutura.Orm.ModuloTeste;

namespace GeradorDeTestes.WebApp;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddScoped<IRepositorioDisciplina, RepositorioDisciplinaEmOrm>();
        builder.Services.AddScoped<IRepositorioMateria, RepositorioMateriaEmOrm>();
        builder.Services.AddScoped<IRepositorioTeste, RepositorioTesteEmOrm>();
        

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
