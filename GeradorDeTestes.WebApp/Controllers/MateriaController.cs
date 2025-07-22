using GeradorDeTestes.Dominio.Compartilhado;
using GeradorDeTestes.Dominio.ModuloMateria;
using GeradorDeTestes.Infraestrutura.Orm.Compartilhado;
using GeradorDeTestes.WebApp.Extensions;
using GeradorDeTestes.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace GeradorDeTestes.WebApp.Controllers
{
    [Route("materias")]
    public class MateriaController : Controller
    {
        private readonly GeradorDeTestesDbContext contexto;
        private readonly IUnityOfWork unityOfWork;
        private readonly IRepositorioMateria repositorioMateria;

        public MateriaController(GeradorDeTestesDbContext contexto, IRepositorioMateria repositorioMateria, IUnityOfWork unityOfWork)
        {
            this.contexto = contexto;
            this.unityOfWork = unityOfWork;
            this.repositorioMateria = repositorioMateria;
        }

        public IActionResult Index()
        {
            var registros = repositorioMateria.SelecionarRegistros();

            var visualizarVM = new VisualizarMateriasViewModel(registros);

            return View(registros);
        }

        [HttpGet("cadastrar")]
        public IActionResult Cadastrar()
        {
            var cadastrarVM = new CadastrarMateriaViewModel();

            return View(cadastrarVM);
        }

        [HttpPost("cadastrar")]
        [ValidateAntiForgeryToken]
        public IActionResult Cadastrar(CadastrarMateriaViewModel cadastrarVM)
        {
            var registros = repositorioMateria.SelecionarRegistros();

            foreach (var item in registros)
            {
                if (item.Nome.Equals(cadastrarVM.Nome))
                {
                    ModelState.AddModelError("CadastroUnico", "Já existe um registro com este nome.");
                    break;
                }
            }

            if (!ModelState.IsValid)
                return View(cadastrarVM);

            var entidade = cadastrarVM.ParaEntidade();

            repositorioMateria.CadastrarRegistro(entidade);

            contexto.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("editar/{id:guid}")]
        public ActionResult Editar(Guid id)
        {
            var registroSelecionado = repositorioMateria.SelecionarRegistroPorId(id);

            var editarVM = new EditarMateriaViewModel(
                    id,
                    registroSelecionado.Nome,
                    registroSelecionado.Disciplina,
                    registroSelecionado.Serie
                );

            return View(editarVM);
        }

        [HttpPost("editar/{id:guid}")]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Guid id, EditarMateriaViewModel editarVM)
        {
            var registros = repositorioMateria.SelecionarRegistros();

            foreach (var item in registros)
            {
                if (!item.Id.Equals(id) && item.Nome.Equals(editarVM.Nome))
                {
                    ModelState.AddModelError("CadastroUnico", "Já existe uma matéria com esse nome");
                    break;
                }
            }

            if (!ModelState.IsValid)
                return View(editarVM);

            var entidadeEditada = editarVM.ParaEntidade();

            repositorioMateria.EditarRegistro(id, entidadeEditada);

            contexto.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("excluir/{id:guid}")]
        public IActionResult Excluir(Guid id)
        {
            var registroSelecionado = repositorioMateria.SelecionarRegistroPorId(id);

            var excluirVM = new ExcluirMateriaViewModel(registroSelecionado.Id, registroSelecionado.Nome);

            return View(excluirVM);
        }

        [HttpPost("excluir/{id:guid}")]
        public IActionResult ExcluirConfirmado(Guid id)
        {
            repositorioMateria.ExcluirRegistro(id);

            contexto.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("detalhes/{id:guid}")]
        public IActionResult Detalhes(Guid id)
        {
            var registroSelecionado = repositorioMateria.SelecionarRegistroPorId(id);

            var detalhesVM = new DetalhesMateriaViewModel(
                id,
                registroSelecionado.Nome,
                registroSelecionado.Disciplina,
                registroSelecionado.Serie
            );

            return View(detalhesVM);
        }
    }
}
