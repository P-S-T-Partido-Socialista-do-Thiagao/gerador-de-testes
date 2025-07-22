using GeradorDeTestes.Dominio.ModuloQuestao;
using GeradorDeTestes.Infraestrutura.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace GeradorDeTestes.Infraestrutura.Orm.ModuloQuestao;

public class RepositorioQuestaoEmOrm : RepositorioBaseEmOrm<Questao>, IRepositorioQuestao 
{
    public RepositorioQuestaoEmOrm(GeradorDeTestesDbContext contexto) : base(contexto) 
    {
    }
    public Alternativa? SelecionarAlternativa(Questao questao, Guid idAlternativa)
    {
        return questao.Alternativas.FirstOrDefault(a => a.Id.Equals(idAlternativa));
    }

    public void RemoverRegistros(List<Questao> questoes)
    {
        contexto.Questoes.RemoveRange(questoes);
        contexto.SaveChanges();
    }
    public override Questao? SelecionarRegistroPorId(Guid idRegistro)
    {
        return registros.Include(q => q.Materia)
            .ThenInclude(m => m.Disciplina)
            .Include(q => q.Alternativas)
            .Include(q => q.Testes)
            .FirstOrDefault(c => c.Id.Equals(idRegistro));
    }

    public override List<Questao> SelecionarRegistros()
    {
        return registros.Include(q => q.Materia)
            .ThenInclude(m => m.Disciplina)
            .Include(q => q.Alternativas)
            .Include(q => q.Testes)
            .OrderBy(q => q.Materia.Serie)
            .ThenBy(q => q.Enunciado)
            .ToList();
    }

    public List<Questao> SelecionarNaoFinalizadosAntigos(TimeSpan tempoMaximo)
    {
        throw new NotImplementedException();
    }

    public List<Questao> SelecionarNaoFinalizados()
    {
        throw new NotImplementedException();
    }
}
