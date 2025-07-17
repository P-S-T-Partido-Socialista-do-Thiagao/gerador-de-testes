using ControleDeBar.Infraestrutura.Orm.Compartilhado;
using GeradorDeTestes.Dominio.ModuloDisciplina;
using Microsoft.AspNetCore.Mvc;

namespace GeradorDeTestes.WebApp.Controllers;

[Route("disciplinas")]
public class DisciplinaController : Controller
{
    private readonly GeradorDeTestesDbContext contexto;
    private readonly IRepositorioDisciplina repositorioDisciplina;

    public DisciplinaController(GeradorDeTestesDbContext contexto, IRepositorioDisciplina repositorioDisciplina)
    {
        this.contexto = contexto;
        this.repositorioDisciplina = repositorioDisciplina;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var disciplinas = repositorioDisciplina.SelecionarRegistros();

      
        return View(disciplinas);
    }
}
