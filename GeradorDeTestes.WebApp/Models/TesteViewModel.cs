using GeradorDeTestes.Dominio.ModuloDisciplina;
using GeradorDeTestes.Dominio.Compartilhado;
using GeradorDeTestes.Dominio.ModuloMateria;
using GeradorDeTestes.Dominio.ModuloQuestao;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
using GeradorDeTestes.Dominio.ModuloTeste;
using GeradorDeTestes.WebApp.Extensions;

namespace GeradorDeTestes.WebApp.Models;

public abstract class FormularioTesteViewModel
{
    [Required(ErrorMessage = "O campo \"Título\" é obrigatório.")]
    public string Titulo { get; set; }
    public Disciplina Disciplina { get; set; }
    public Materia Materia { get; set; }
    public SeriesEnum Serie { get; set; }
    public List<Questao> Questoes { get; set; }
    public int QuantidadeQuestoes { get; set; }
    public bool Recuperacao { get; set; }
}
public class CadastrarTesteViewModel : FormularioTesteViewModel
{
    public CadastrarTesteViewModel()
    {
    }

    public CadastrarTesteViewModel(string titulo) : this()
    {
        Titulo = titulo;
    }
}

public class EditarTesteViewModel : FormularioTesteViewModel
{
    public Guid Id { get; set; }

    public EditarTesteViewModel()
    {
    }
    public EditarTesteViewModel(Guid id, string titulo, Disciplina disciplina, Materia materia, SeriesEnum serie, List<Questao> questoes, int quantidadeQuestoes, bool recuperacao)
    {
        Id = id;
        Titulo = titulo;
        Disciplina = disciplina;
        Materia = materia;
        Serie = serie;
        Questoes = questoes;
        QuantidadeQuestoes = quantidadeQuestoes;
        Recuperacao = recuperacao;
    }
}

public class ExcluirTesteViewModel
{
    public Guid Id { get; set; }
    public string Titulo { get; set; }
    public Disciplina Disciplina { get; set; }
    public Materia Materia { get; set; }
    public SeriesEnum Serie { get; set; }
    public List<Questao> Questoes { get; set; }
    public int QuantidadeQuestoes { get; set; }
    public bool Recuperacao { get; set; }

    public ExcluirTesteViewModel() { }

    public ExcluirTesteViewModel(Guid id, string titulo)
    {
        Id = id;
        Titulo = titulo;
    }
}

public class VisualizarTesteViewModel
{
    public List<DetalhesTesteViewModel> Testes { get; }

    public VisualizarTesteViewModel(List<Teste> testes)
    {
        Testes = [];

        foreach (var teste in testes)
        {
            var detalhesVM = teste.ParaDetalhesVM();

            Testes.Add(detalhesVM);
        }
    }
}

public class DetalhesTesteViewModel
{
    public Guid Id { get; set; }
    public string Titulo { get; set; }
    public Disciplina Disciplina { get; set; }
    public Materia Materia { get; set; }
    public SeriesEnum Serie { get; set; }
    public List<Questao> Questoes { get; set; }
    public int QuantidadeQuestoes { get; set; }
    public bool Recuperacao { get; set; }

    public DetalhesTesteViewModel(Guid id, string titulo, Disciplina disciplina, Materia materia, SeriesEnum serie, List<Questao> questoes, int quantidadeQuestoes, bool recuperacao)
    {
        Id = id;
        Titulo = titulo;
        Disciplina = disciplina;
        Serie = serie;
    }
}
