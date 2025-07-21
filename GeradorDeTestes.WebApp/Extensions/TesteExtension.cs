using GeradorDeTestes.Dominio.ModuloTeste;
using GeradorDeTestes.WebApp.Models;

namespace GeradorDeTestes.WebApp.Extensions;

public static class TesteExtension
{
    public static Teste ParaEntidade(this FormularioTesteViewModel formularioVM)
    {
        return new Teste(formularioVM.Titulo, formularioVM.Disciplina, formularioVM.Materia, formularioVM.Serie, formularioVM.Questoes, formularioVM.Recuperacao, formularioVM.QuantidadeQuestoes);
    }

    public static DetalhesTesteViewModel ParaDetalhesVM(this Teste teste)
    {
        return new DetalhesTesteViewModel(
            teste.Id,
            teste.Titulo,
            teste.Disciplina,
            teste.Materia,
            teste.Serie,
            teste.Questoes,
            teste.QuantidadeQuestoes,
            teste.Recuperacao
            );
    }
}
