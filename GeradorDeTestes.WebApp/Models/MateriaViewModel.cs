using GeradorDeTestes.Dominio.ModuloDisciplina;
using GeradorDeTestes.Dominio.ModuloMateria;
using GeradorDeTestes.Dominio.Compartilhado;
using System.ComponentModel.DataAnnotations;
using GeradorDeTestes.WebApp.Extensions;

namespace GeradorDeTestes.WebApp.Models;

public abstract class FormularioMateriaViewModel
{
    [Required(ErrorMessage = "O campo \"Nome\" é obrigatório.")]
    public string Nome { get; set; }
    public Disciplina Disciplina { get; set; }
    public SeriesEnum Serie { get; set; }
}
    public class CadastrarMateriaViewModel : FormularioMateriaViewModel
    {
        public CadastrarMateriaViewModel()
        {
        }

        public CadastrarMateriaViewModel(string nome) : this()
        {
            Nome = nome;
        }
    }

    public class EditarMateriaViewModel : FormularioMateriaViewModel
    {
        public Guid Id { get; set; }

        public EditarMateriaViewModel()
        {
        }
        public EditarMateriaViewModel(Guid id, string nome,  Disciplina disciplina, SeriesEnum serie)
        {
            Id = id;
            Nome = nome;
            Disciplina = disciplina;
            Serie = serie;
        }
    }

    public class ExcluirMateriaViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public Disciplina Disciplina { get; set; }
        public SeriesEnum Serie { get; set; }

        public ExcluirMateriaViewModel() { }
        
        public ExcluirMateriaViewModel(Guid id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }
    
    public class VisualizarMateriasViewModel
    {
        public List<DetalhesMateriaViewModel> Materias { get; }

        public VisualizarMateriasViewModel(List<Materia> materias)
        {
            Materias = [];
            
            foreach (var materia in materias)
            {
                var detalhesVM = materia.ParaDetalhesVM();

                Materias.Add(detalhesVM);
            }
        }
    }

    public class DetalhesMateriaViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public Disciplina Disciplina { get; set; }
        public SeriesEnum Serie { get; set; }

        public DetalhesMateriaViewModel(Guid id, string nome, Disciplina disciplina, SeriesEnum serie)
        {
            Id = id;
            Nome = nome;
            Disciplina = disciplina;
            Serie = serie;
        }
    }