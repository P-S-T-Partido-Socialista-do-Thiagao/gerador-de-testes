using GeradorDeTestes.Dominio.ModuloMateria;
using GeradorDeTestes.WebApp.Models;
using static GeradorDeTestes.WebApp.Models.FormularioMateriaViewModel;

namespace GeradorDeTestes.WebApp.Extensions
{
    public static class MateriaExtension
    {
        public static Materia ParaEntidade(this FormularioMateriaViewModel formularioVM)
        {
            return new Materia(formularioVM.Nome, formularioVM.Disciplina, formularioVM.Serie);
        }

        public static DetalhesMateriaViewModel ParaDetalhesVM(this Materia materia)
        {
            return new DetalhesMateriaViewModel(
                materia.Id,
                materia.Nome,
                materia.Disciplina,
                materia.Serie
                );
        }

    }
}
