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
    public class DoencasController : Controller
    {
        private readonly IDoencaAppService _doencaAppService;

        public DoencasController(IDoencaAppService doencaAppService)
        {
            _doencaAppService = doencaAppService;
        }

        // GET: Doencas
        [ClaimsAuthorize("PermissoesCliente", "CL")]
        [Route("listar-doencas")]
        public ActionResult Index()
        {
            return View(_doencaAppService.ObterTodos());
        }

        // GET: Doencas/Details/5
        [ClaimsAuthorize("PermissoesCliente", "CD")]
        [Route("{id:guid}/detalhe-doenca")]
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var doencaViewModel = _doencaAppService.ObterPorId(id.Value);

            if (doencaViewModel == null)
            {
                return HttpNotFound();
            }
            return View(doencaViewModel);
        }

        // GET: Doencas/Create
        [ClaimsAuthorize("PermissoesCliente", "CI")]
        [Route("nova-doenca")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Doencas/Create
        [ClaimsAuthorize("PermissoesCliente", "CI")]
        [Route("nova-doenca")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( DoencaViewModel doencaViewModel)
        {
            if (ModelState.IsValid)
            {
                doencaViewModel = _doencaAppService.Adicionar(doencaViewModel);

                if(!doencaViewModel.ValidationResult.IsValid)
                {
                    foreach (var erro in doencaViewModel.ValidationResult.Erros)
                    {
                        ModelState.AddModelError(string.Empty, erro.Message);
                    }
                    return View(doencaViewModel);
                }
                return RedirectToAction("Index");
            }
            return View(doencaViewModel);
        }

        // GET: Doencas/Edit/5
        [ClaimsAuthorize("PermissoesCliente", "CE")]
        [Route("{id:guid}/editar-doenca")]
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var doencaViewModel = _doencaAppService.ObterPorId(id.Value);

            if (doencaViewModel == null)
            {
                return HttpNotFound();
            }
            return View(doencaViewModel);
        }

        // POST: Doencas/Edit/5
        [ClaimsAuthorize("PermissoesCliente", "CE")]
        [Route("{id:guid}/editar-doenca")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DoencaViewModel doencaViewModel)
        {
            if (ModelState.IsValid)
            {
                _doencaAppService.Atualizar(doencaViewModel);
                return RedirectToAction("Index");
            }
            return View(doencaViewModel);
        }

        // GET: Doencas/Delete/5
        [ClaimsAuthorize("PermissoesCliente", "CX")]
        [Route("{id:guid}/excluir-doenca")]
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var doencaViewModel = _doencaAppService.ObterPorId(id.Value);
            if (doencaViewModel == null)
            {
                return HttpNotFound();
            }
            return View(doencaViewModel);
        }

        // POST: Doencas/Delete/5,
        [ClaimsAuthorize("PermissoesCliente", "CX")]
        [Route("{id:guid}/excluir-doenca")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _doencaAppService.remover(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _doencaAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
