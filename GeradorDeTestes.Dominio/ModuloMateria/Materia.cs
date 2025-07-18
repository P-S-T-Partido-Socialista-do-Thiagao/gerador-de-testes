using GeradorDeTestes.Dominio.Compartilhado;
using GeradorDeTestes.Dominio.ModuloDisciplina;

namespace GeradorDeTestes.Dominio.ModuloMateria;

public class Materia : EntidadeBase<Materia>
{
    public string Nome { get; set; }
    public Disciplina Disciplina { get; set; }
    public SeriesEnum Serie { get; set; }

    public Materia() { }

    public Materia(string nome,Disciplina disciplina, SeriesEnum serie) :this()
    {
        Nome = nome;
        Disciplina = disciplina;
        Serie = serie;
    }

    public override void AtualizarRegistro(Materia registroEditado)
    {
        Nome = registroEditado.Nome;
        Disciplina = registroEditado.Disciplina;
        Serie = registroEditado.Serie;
    }
}
