using GeradorDeTestes.Dominio.Compartilhado;
using GeradorDeTestes.Dominio.ModuloMateria;

namespace GeradorDeTestes.Dominio.ModuloDisciplina;
public class Disciplina : EntidadeBase<Disciplina>
{
    public string Nome { get; set; }
    public List<Materia> Materias { get; set; }

    public Disciplina()
    {
        Materias = new List<Materia>();
    }

    public Disciplina(string nome) : this() 
    {
        Nome = nome;
    }
    public override void AtualizarRegistro(Disciplina registroEditado)
    {
        Nome = registroEditado.Nome;
        Materias = registroEditado.Materias;
    }
}
