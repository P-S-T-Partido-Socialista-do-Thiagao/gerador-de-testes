
using ControleDeBar.Infraestrutura.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;

public static class EntityFrameworkConfig
{
    public static void AddEntityFrameworkConfig(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        var connectionString = configuration["SQL_CONNECTION_STRING"];

        services.AddDbContext<GeradorDeTestesDbContext>(options =>
            options.UseNpgsql(connectionString));
    }
}