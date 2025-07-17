using ControleDeBar.Infraestrutura.Orm.Compartilhado;
using GeradorDeTestes.Dominio.ModuloDisciplina;

namespace GeradorDeTestes.Infraestrutura.Orm.ModuloDisciplina;
public class RepositorioDisciplinaEmOrm : RepositorioBaseEmOrm<Disciplina>, IRepositorioDisciplina
{
    public RepositorioDisciplinaEmOrm(GeradorDeTestesDbContext contexto) : base(contexto)
    {
    }
}
