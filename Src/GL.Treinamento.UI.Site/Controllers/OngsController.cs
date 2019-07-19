using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GL.Treinamento.Infra.CrossCutting.MvcFilters;
using GL.Treinamento.UI.Site.Models;
using N.Treinamento.Application.Interfaces;
using N.Treinamento.Application.ViewModels;

namespace GL.Treinamento.UI.Site.Controllers
{
    [Authorize]

    [RoutePrefix("gestao/cadastros")]
    public class OngsController : Controller
    {
        private readonly IOngAppService _ongAppService;

        private readonly IClienteAppService _clienteAppService;

        public OngsController(IOngAppService ongAppService, IClienteAppService clienteAppService)
        {
            _ongAppService = ongAppService;

            _clienteAppService = clienteAppService;
        }

        // GET: Ongs
        [ClaimsAuthorize("PermissoesCliente", "CL")]
        [Route("listar-ongs")]
        public ActionResult Index()
        {
            return View(_ongAppService.ObterTodos());
        }

        // GET: Ongs/Details/5
        [ClaimsAuthorize("PermissoesCliente", "CD")]
        [Route("{id:guid}/detalhe-ong")]
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var ongViewModel = _ongAppService.ObterPorId(id.Value);

            if (ongViewModel == null)
            {
                return HttpNotFound();
            }
            return View(ongViewModel);
        }

        // GET: Ongs/Create
        [ClaimsAuthorize("PermissoesCliente", "CI")]
        [Route("nova-ong")]
        public ActionResult Create()
        {
            ViewBag.VBResponsavel = _clienteAppService.ObterTodos();
            return View();
        }

        // POST: Ongs/Create
        [ClaimsAuthorize("PermissoesCliente", "CI")]
        [Route("nova-ong")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OngEnderecoViewModel ongEnderecoViewModel)
        {
            if (ModelState.IsValid)
            {
                ongEnderecoViewModel = _ongAppService.Adicionar(ongEnderecoViewModel);

                if (!ongEnderecoViewModel.ValidationResult.IsValid)
                {
                    foreach (var erro in ongEnderecoViewModel.ValidationResult.Erros)
                    {
                        ModelState.AddModelError(string.Empty, erro.Message);
                    }
                    return View(ongEnderecoViewModel); //CASO TENHA ALGUM ERRO RETORNA PARA A VIEW DE CADASTRO
                }
                return RedirectToAction("Index");
            }

            return View(ongEnderecoViewModel);
        }

        // GET: Ongs/Edit/5
        [ClaimsAuthorize("PermissoesCliente", "CE")]
        [Route("{id:guid}/editar-ong")]
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var ongViewModel = _ongAppService.ObterPorId(id.Value);

            if (ongViewModel == null)
            {
                return HttpNotFound();
            }
            return View(ongViewModel);
        }

        // POST: Ongs/Edit/5
        [ClaimsAuthorize("PermissoesCliente", "CE")]
        [Route("{id:guid}/editar-ong")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OngViewModel ongViewModel)
        {
            if (ModelState.IsValid)
            {
                _ongAppService.Atualizar(ongViewModel);
                return RedirectToAction("Index");
            }
            return View(ongViewModel);
        }

        // GET: Ongs/Delete/5
        [ClaimsAuthorize("PermissoesCliente", "CX")]
        [Route("{id:guid}/excluir-ong")]
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var ongViewModel = _ongAppService.ObterPorId(id.Value);

            if (ongViewModel == null)
            {
                return HttpNotFound();
            }
            return View(ongViewModel);
        }

        // POST: Ongs/Delete/5
        [ClaimsAuthorize("PermissoesCliente", "CX")]
        [Route("{id:guid}/excluir-ong")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _ongAppService.remover(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _ongAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
