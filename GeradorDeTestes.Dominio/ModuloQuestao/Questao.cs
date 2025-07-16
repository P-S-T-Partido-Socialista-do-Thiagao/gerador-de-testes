using GeradorDeTestes.Dominio.Compartilhado;
using GeradorDeTestes.Dominio.ModuloMateria;

namespace GeradorDeTestes.Dominio.ModuloQuestao;
public class Questao : EntidadeBase<Questao>
{
    public Materia Materia { get; set; }
    public string Enunciado { get; set; }
    public List<Alternativa> Alternativas { get; set; }

    public Questao()
    {
        Alternativas = new List<Alternativa>();
    }

    public Questao(Materia materia, string enunciado, List<Alternativa> alternativas) : this()
    {
        Materia = materia;
        Enunciado = enunciado;
        Alternativas = alternativas;
    }
    public override void AtualizarRegistro(Questao registroEditado)
    {
        Materia = registroEditado.Materia;
        Enunciado = registroEditado.Enunciado;
        Alternativas = registroEditado.Alternativas;
    }
}
