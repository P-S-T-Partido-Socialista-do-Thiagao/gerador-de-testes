using GeradorDeTestes.Dominio.Compartilhado;
using GeradorDeTestes.Dominio.ModuloDisciplina;
using GeradorDeTestes.Infraestrutura.Orm.Compartilhado;
using GeradorDeTestes.WebApp.Extensions;
using GeradorDeTestes.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace GeradorDeTestes.WebApp.Controllers;

[Route("disciplinas")]
public class DisciplinaController : Controller
{
    private readonly GeradorDeTestesDbContext contexto;
    private readonly IUnityOfWork unityOfWork;
    private readonly IRepositorioDisciplina repositorioDisciplina;

    public DisciplinaController(GeradorDeTestesDbContext contexto, IRepositorioDisciplina repositorioDisciplina, IUnityOfWork unityOfWork)
    {
        this.contexto = contexto;
        this.unityOfWork = unityOfWork;
        this.repositorioDisciplina = repositorioDisciplina;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var disciplinas = repositorioDisciplina.SelecionarRegistros();

        var visualizarVM = new VisualizarDisciplinasViewModel(disciplinas);

        return View(disciplinas);
    }

    [HttpGet("cadastrar")]
    public IActionResult Cadastrar()
    {
        var cadastrarVM = new CadastrarDisciplinaViewModel();

        return View(cadastrarVM);
    }

    [HttpPost("cadastrar")]
    [ValidateAntiForgeryToken]
    public IActionResult Cadastrar(CadastrarDisciplinaViewModel cadastrarVM)
    {
        var registros = repositorioDisciplina.SelecionarRegistros();

        foreach (var item in registros)
        {
            if (item.Nome.Equals(cadastrarVM.Nome))
            {
                ModelState.AddModelError("CadastroUnico", "Já existe uma disciplina cadastrada com esse nome.");
                break;
            }
        }

        if (!ModelState.IsValid)
            return View(cadastrarVM);

        var entidade = cadastrarVM.ParaEntidade();

        var transacao = contexto.Database.BeginTransaction();

        try
        {
            repositorioDisciplina.CadastrarRegistro(entidade);

            contexto.SaveChanges();
            transacao.Commit();

        }
        catch (Exception)
        {
            transacao.Rollback();

            throw;
        }

        return RedirectToAction(nameof(Index));
    }

    [HttpGet("editar/{id:guid}")]
    public ActionResult Editar(Guid id)
    {
        var registroSelecionado = repositorioDisciplina.SelecionarRegistroPorId(id);

        var editarVM = new EditarDisciplinaViewModel(
            id,
            registroSelecionado.Nome,
            registroSelecionado.Materias
        );

        return View(editarVM);
    }

    [HttpPost("editar/{id:guid}")]
    [ValidateAntiForgeryToken]
    public ActionResult Editar(Guid id, EditarDisciplinaViewModel editarVM)
    {
        var registros = repositorioDisciplina.SelecionarRegistros();

        foreach (var item in registros)
        {
            if (!item.Id.Equals(id) && item.Nome.Equals(editarVM.Nome))
            {
                ModelState.AddModelError("CadastroUnico", "Já existe uma disciplina registrada com este nome.");
                break;
            }
        }

        if (!ModelState.IsValid)
            return View(editarVM);

        var entidadeEditada = editarVM.ParaEntidade();

        var transacao = contexto.Database.BeginTransaction();

        try
        {
            repositorioDisciplina.EditarRegistro(id, entidadeEditada);

            contexto.SaveChanges();
            transacao.Commit();
        }
        catch (Exception)
        {
            transacao.Rollback();

            throw;
        }

        return RedirectToAction(nameof(Index));
    }


    [HttpGet("excluir/{id:guid}")]
    public ActionResult Excluir(Guid id)
    {
        var registroSelecionado = repositorioDisciplina.SelecionarRegistroPorId(id);

        var excluirVM = new ExcluirDisciplinaViewModel(registroSelecionado.Id, registroSelecionado.Nome, registroSelecionado.Materias);

        return View(excluirVM);
    }

    [HttpPost("excluir/{id:guid}")]
    public ActionResult ExcluirConfirmado(Guid id)
    {
        var transacao = contexto.Database.BeginTransaction();

        try
        {
            repositorioDisciplina.ExcluirRegistro(id);

            contexto.SaveChanges();

            transacao.Commit();
        }
        catch (Exception)
        {
            transacao.Rollback();

            throw;
        }

        return RedirectToAction(nameof(Index));
    }

    [HttpGet("detalhes/{id:guid}")]
    public ActionResult Detalhes(Guid id)
    {
        var registroSelecionado = repositorioDisciplina.SelecionarRegistroPorId(id);

        var detalhesVM = new DetalhesDisciplinaViewModel(
            id,
            registroSelecionado.Nome,
            registroSelecionado.Materias
        );

        return View(detalhesVM);
    }
}
