using GeradorDeTestes.Dominio.Compartilhado;
using GeradorDeTestes.Dominio.ModuloDisciplina;
using GeradorDeTestes.Dominio.ModuloMateria;
using GeradorDeTestes.Dominio.ModuloQuestao;

namespace GeradorDeTestes.Dominio.ModuloTeste;
public class Teste : EntidadeBase<Teste>
{
    public string Titulo { get; set; }
    public Disciplina Disciplina { get; set; }
    public Materia Materia { get; set; }
    public ModuloMateria.EnumSerie Serie { get; set; }
    public List<Questao> Questoes { get; set; }
    public int QuantidadeQuestoes { get; set; }
    public bool Recuperacao { get; set; }

    public Teste()
    {
        Questoes = new List<Questao>();
    }

    public Teste(string titulo, Disciplina disciplina, Materia materia, EnumSerie serie, 
        List<Questao> questoes, bool recuperacao, int quantidadeQuestoes)
    {
        Titulo = titulo;
        Disciplina = disciplina;
        Materia = materia;
        Serie = serie;
        Questoes = questoes;
        QuantidadeQuestoes = quantidadeQuestoes;
        Recuperacao = recuperacao;
    }

    public override void AtualizarRegistro(Teste registroEditado)
    {
        Titulo = registroEditado.Titulo;
        Disciplina = registroEditado.Disciplina;
        Materia = registroEditado.Materia;
        Serie = registroEditado.Serie;
        Questoes = registroEditado.Questoes;
        QuantidadeQuestoes = registroEditado.QuantidadeQuestoes;
        Recuperacao = registroEditado.Recuperacao;
    }
}
