using GeradorDeTestes.Dominio.ModuloMateria;
using GeradorDeTestes.Dominio.Compartilhado;

namespace GeradorDeTestes.Dominio.ModuloQuestao;
public interface IRepositorioQuestao : IRepositorio<Questao>
{
    List<Questao> SelecionarQuestoesPorDisciplinaESerie(Guid disciplinaId, EnumSerie serie, int quantidadeQuestoes);
    List<Questao> SelecionarQuestoesPorMateria(Guid materiaId, int quantidadeQuestoes);
}
