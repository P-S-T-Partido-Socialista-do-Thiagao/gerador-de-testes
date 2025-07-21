using GeradorDeTestes.Dominio.ModuloTeste;
using GeradorDeTestes.Infraestrutura.Orm.Compartilhado;

namespace GeradorDeTestes.Infraestrutura.Orm.ModuloTeste;

public class RepositorioTesteEmOrm : RepositorioBaseEmOrm<Teste>, IRepositorioTeste
{
    public RepositorioTesteEmOrm(GeradorDeTestesDbContext contexto) : base(contexto)
    {
    }
}
