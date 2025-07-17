using GeradorDeTestes.Dominio.ModuloDisciplina;
using GeradorDeTestes.WebApp.Models;
using System.Runtime.CompilerServices;

namespace GeradorDeTestes.WebApp.Extensions;

public static class DisciplinaExtensions
{
    public static Disciplina ParaEntidade(this FormularioDisciplinaViewModel formularioVM)
    {
        return new Disciplina(formularioVM.Nome);
    }

    public static DetalhesDisciplinaViewModel ParaDetalhesVM(this Disciplina disciplina)
    {
        return new DetalhesDisciplinaViewModel(
            disciplina.Id,
            disciplina.Nome,
            disciplina.Materias
            );
    }
}
