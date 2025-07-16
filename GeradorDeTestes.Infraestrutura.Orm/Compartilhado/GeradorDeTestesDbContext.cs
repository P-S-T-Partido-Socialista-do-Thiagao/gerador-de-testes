using Microsoft.EntityFrameworkCore;

namespace ControleDeBar.Infraestrutura.Orm.Compartilhado;

public class GeradorDeTestesDbContext : DbContext
{

    public GeradorDeTestesDbContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var assembly = typeof(GeradorDeTestesDbContext).Assembly;

        modelBuilder.ApplyConfigurationsFromAssembly(assembly);

        base.OnModelCreating(modelBuilder);
    }
}
