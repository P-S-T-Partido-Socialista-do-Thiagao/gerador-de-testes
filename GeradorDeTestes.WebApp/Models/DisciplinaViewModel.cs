using GeradorDeTestes.Dominio.ModuloDisciplina;
using GeradorDeTestes.Dominio.ModuloMateria;
using GeradorDeTestes.WebApp.Extensions;
using System.ComponentModel.DataAnnotations;

namespace GeradorDeTestes.WebApp.Models;

public abstract class FormularioDisciplinaViewModel
{
    [Required(ErrorMessage = "O campo \"Nome\" é obrigatório.")]
    public string Nome { get; set; }
    public List<Materia> Materias { get; set; }
}

public class CadastrarDisciplinaViewModel : FormularioDisciplinaViewModel
{
    public CadastrarDisciplinaViewModel()
    {
    }

    public CadastrarDisciplinaViewModel(string nome) : this()
    {
        Nome = nome;
    }
}

public class EditarDisciplinaViewModel : FormularioDisciplinaViewModel
{
    public Guid Id { get; set; }

    public EditarDisciplinaViewModel()
    {
        Materias = new List<Materia>();
    }

    public EditarDisciplinaViewModel(Guid id, string nome, List<Materia> materias) : this()
    {
        Id = id;
        Nome = nome;
        Materias = materias;
    }
}

public class ExcluirDisciplinaViewModel
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public List<Materia> Materias { get; set; }

    public ExcluirDisciplinaViewModel() { }

    public ExcluirDisciplinaViewModel(Guid id, string nome, List<Materia> materias) : this()
    {
        Id = id;
        Nome = nome;
        Materias = materias;
    }
}

public class VisualizarDisciplinasViewModel
{
    public List<DetalhesDisciplinaViewModel> Disciplinas { get; }

    public VisualizarDisciplinasViewModel(List<Disciplina> disciplinas)
    {
        Disciplinas = [];

        foreach (var disciplina in disciplinas)
        {
            var detalhesVM = disciplina.ParaDetalhesVM();

            Disciplinas.Add(detalhesVM);
        }
    }
}

public class DetalhesDisciplinaViewModel
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public List<Materia> Materias { get; set; }

    public DetalhesDisciplinaViewModel(Guid id, string nome, List<Materia> materias)
    {
        Id = id;
        Nome = nome;
        Materias = materias;
    }
}
