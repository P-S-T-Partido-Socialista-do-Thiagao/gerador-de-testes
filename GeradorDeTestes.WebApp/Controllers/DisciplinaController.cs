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
    private readonly IRepositorioDisciplina repositorioDisciplina;
    private readonly IUnityOfWork unityOfWork;
    private readonly ILogger<DisciplinaController> logger;

    public DisciplinaController(
        IRepositorioDisciplina repositorioDisciplina,
        IUnityOfWork unityOfWork,
        ILogger<DisciplinaController> logger
    )
    {
        this.unityOfWork = unityOfWork;
        this.logger = logger;
        this.repositorioDisciplina = repositorioDisciplina;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var registros = repositorioDisciplina.SelecionarRegistros();

        var visualizarVM = new VisualizarDisciplinasViewModel(registros);

        return View(visualizarVM);
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

        if (registros.Any(i => i.Nome.Equals(cadastrarVM.Nome)))
        {
            ModelState.AddModelError(
                "CadastroUnico",
                "Já existe uma disciplina registrada com este nome."
            );

            return View(cadastrarVM);
        }

        try
        {
            var entidade = FormularioDisciplinaViewModel.ParaEntidade(cadastrarVM);

            repositorioDisciplina.CadastrarRegistro(entidade);

            unityOfWork.Commit();
        }
        catch (Exception ex)
        {
            unityOfWork.RollBack();

            logger.LogError(
                ex,
                "Ocorreu um erro durante o registro de {@ViewModel}.",
                cadastrarVM
            );
        }

        return RedirectToAction(nameof(Index));
    }

    [HttpGet("editar/{id:guid}")]
    public ActionResult Editar(Guid id)
    {
        var registroSelecionado = repositorioDisciplina.SelecionarRegistroPorId(id);

        if (registroSelecionado is null)
            return RedirectToAction(nameof(Index));

        var editarVM = new EditarDisciplinaViewModel(
            id,
            registroSelecionado.Nome
        );

        return View(editarVM);
    }

    [HttpPost("editar/{id:guid}")]
    [ValidateAntiForgeryToken]
    public ActionResult Editar(Guid id, EditarDisciplinaViewModel editarVM)
    {
        var registros = repositorioDisciplina.SelecionarRegistros();

        if (registros.Any(i => !i.Id.Equals(editarVM.Id) && i.Nome.Equals(editarVM.Nome)))
        {
            ModelState.AddModelError(
                "CadastroUnico",
                "Já existe uma disciplina registrada com este nome."
            );

            return View(editarVM);
        }

        try
        {
            var entidadeEditada = FormularioDisciplinaViewModel.ParaEntidade(editarVM);

            repositorioDisciplina.EditarRegistro(id, entidadeEditada);

            unityOfWork.Commit();
        }
        catch (Exception ex)
        {
            unityOfWork.RollBack();

            logger.LogError(
                ex,
                "Ocorreu um erro durante a edição do registro {@ViewModel}.",
                editarVM
            );
        }

        return RedirectToAction(nameof(Index));
    }

    [HttpGet("excluir/{id:guid}")]
    public IActionResult Excluir(Guid id)
    {
        var registroSelecionado = repositorioDisciplina.SelecionarRegistroPorId(id);

        if (registroSelecionado is null)
            return RedirectToAction(nameof(Index));

        var excluirVM = new ExcluirDisciplinaViewModel(
            registroSelecionado.Id,
            registroSelecionado.Nome
        );

        return View(excluirVM);
    }

    [HttpPost("excluir/{id:guid}")]
    [ValidateAntiForgeryToken]
    public IActionResult ExcluirConfirmado(Guid id)
    {
        try
        {
            repositorioDisciplina.ExcluirRegistro(id);

            unityOfWork.Commit();
        }
        catch (Exception ex)
        {
            unityOfWork.RollBack();

            logger.LogError(
                ex,
                "Ocorreu um erro durante a exclusão do registro {Id}.",
                id
            );
        }

        return RedirectToAction(nameof(Index));
    }


    [HttpGet("detalhes/{id:guid}")]
    public IActionResult Detalhes(Guid id)
    {
        var registroSelecionado = repositorioDisciplina.SelecionarRegistroPorId(id);

        if (registroSelecionado is null)
            return RedirectToAction(nameof(Index));

        var detalhesVM = new DetalhesDisciplinaViewModel(
            id,
            registroSelecionado.Nome,
            registroSelecionado.Materias
        );

        return View(detalhesVM);
    }
}