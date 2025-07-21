using GeradorDeTestes.Dominio.ModuloQuestao;
using GeradorDeTestes.Infraestrutura.Orm.Compartilhado;

namespace GeradorDeTestes.Infraestrutura.Orm.ModuloQuestao;

public class RepositorioQuestaoEmOrm : RepositorioBaseEmOrm<Questao> ,IRepositorioQuestao 
{
    public RepositorioQuestaoEmOrm(GeradorDeTestesDbContext contexto) : base(contexto)
    {

    }
}
