using ControleDeBar.Infraestrutura.Orm.Compartilhado;
using GeradorDeTestes.Dominio.ModuloMateria;

namespace GeradorDeTestes.Infraestrutura.Orm.ModuloMateria;
public class RepositorioMateriaEmOrm : RepositorioBaseEmOrm<Materia>, IRepositorioMateria
{
    public RepositorioMateriaEmOrm(GeradorDeTestesDbContext contexto) : base(contexto)
    {
    }
}
