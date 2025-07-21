using GeradorDeTestes.Dominio.ModuloTeste;
using GeradorDeTestes.Infraestrutura.Orm.Compartilhado;
using GeradorDeTestes.WebApp.Extensions;
using GeradorDeTestes.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace GeradorDeTestes.WebApp.Controllers;

    [Route("testes")]
    public class TesteController : Controller
    {
        private readonly GeradorDeTestesDbContext contexto;
        private readonly IRepositorioTeste repositorioTeste;

        public TesteController(GeradorDeTestesDbContext contexto, IRepositorioTeste repositorioTeste)
        {
            this.contexto = contexto;
            this.repositorioTeste = repositorioTeste;
        }

        public IActionResult Index()
        {
            var registros = repositorioTeste.SelecionarRegistros();

            var visualizarVM = new VisualizarTesteViewModel(registros);

            return View(registros);
        }

        [HttpGet("cadastrar")]
        public IActionResult Cadastrar()
        {
            var cadastrarVM = new CadastrarTesteViewModel();

            return View(cadastrarVM);
        }

        [HttpPost("cadastrar")]
        [ValidateAntiForgeryToken]
        public IActionResult Cadastrar(CadastrarTesteViewModel cadastrarVM)
        {
            var registros = repositorioTeste.SelecionarRegistros();

            foreach (var item in registros)
            {
                if (item.Titulo.Equals(cadastrarVM.Titulo))
                {
                    ModelState.AddModelError("CadastroUnico", "Já existe um registro com este titulo.");
                    break;
                }
            }

            if (!ModelState.IsValid)
                return View(cadastrarVM);

            var entidade = cadastrarVM.ParaEntidade();

            repositorioTeste.CadastrarRegistro(entidade);

            contexto.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("editar/{id:guid}")]
        public ActionResult Editar(Guid id)
        {
            var registroSelecionado = repositorioTeste.SelecionarRegistroPorId(id);

            var editarVM = new EditarTesteViewModel(
                    id,
                    registroSelecionado.Titulo,
                    registroSelecionado.Disciplina,
                    registroSelecionado.Materia,
                    registroSelecionado.Serie,
                    registroSelecionado.Questoes,
                    registroSelecionado.QuantidadeQuestoes,
                    registroSelecionado.Recuperacao
                );

            return View(editarVM);
        }

        [HttpPost("editar/{id:guid}")]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Guid id, EditarTesteViewModel editarVM)
        {
            var registros = repositorioTeste.SelecionarRegistros();

            foreach (var item in registros)
            {
                if (!item.Id.Equals(id) && item.Titulo.Equals(editarVM.Titulo))
                {
                    ModelState.AddModelError("CadastroUnico", "Já existe um teste com esse título");
                    break;
                }
            }

            if (!ModelState.IsValid)
                return View(editarVM);

            var entidadeEditada = editarVM.ParaEntidade();

            repositorioTeste.EditarRegistro(id, entidadeEditada);

            contexto.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("excluir/{id:guid}")]
        public IActionResult Excluir(Guid id)
        {
            var registroSelecionado = repositorioTeste.SelecionarRegistroPorId(id);

            var excluirVM = new ExcluirMateriaViewModel(registroSelecionado.Id, registroSelecionado.Titulo);

            return View(excluirVM);
        }

        [HttpPost("excluir/{id:guid}")]
        public IActionResult ExcluirConfirmado(Guid id)
        {
            repositorioTeste.ExcluirRegistro(id);

            contexto.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("detalhes/{id:guid}")]
        public IActionResult Detalhes(Guid id)
        {
            var registroSelecionado = repositorioTeste.SelecionarRegistroPorId(id);

            var detalhesVM = new DetalhesTesteViewModel(
                id,
                registroSelecionado.Titulo,
                registroSelecionado.Disciplina,
                registroSelecionado.Materia,
                registroSelecionado.Serie,
                registroSelecionado.Questoes,
                registroSelecionado.QuantidadeQuestoes,
                registroSelecionado.Recuperacao
            );

            return View(detalhesVM);
        }
    }