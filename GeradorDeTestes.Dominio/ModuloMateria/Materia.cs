using GeradorDeTestes.Dominio.Compartilhado;
using GeradorDeTestes.Dominio.ModuloDisciplina;
using GeradorDeTestes.Dominio.ModuloQuestao;
using GeradorDeTestes.Dominio.ModuloTeste;

namespace GeradorDeTestes.Dominio.ModuloMateria;

public class Materia : EntidadeBase<Materia>
{
    public string Nome { get; set; }
    public Disciplina Disciplina { get; set; }
    public EnumSerie Serie { get; set; }
    public List<Questao> Questoes { get; set; }
    public List<Teste> Testes { get; set; }

    public Materia() { }

    public Materia(string nome,Disciplina disciplina, EnumSerie serie) :this()
    {
        Nome = nome;
        Disciplina = disciplina;
        Serie = serie;
    }

    public void AderirQuestao(Questao questao)
    {
        Questoes.Add(questao);
    }

    public void RemoverQuestao(Questao questao)
    {
        Questoes.Remove(questao);
    }


    public override void AtualizarRegistro(Materia registroEditado)
    {
        Nome = registroEditado.Nome;
        Disciplina = registroEditado.Disciplina;
        Serie = registroEditado.Serie;
    }
}
