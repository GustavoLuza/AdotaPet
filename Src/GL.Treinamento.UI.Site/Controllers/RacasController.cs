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
    public class RacasController : Controller
    {
        private readonly IRacaAppService _racaAppService;

        public RacasController(IRacaAppService racaAppService)
        {
            _racaAppService = racaAppService;
        }

        // GET: Racas
        [ClaimsAuthorize("PermissoesCliente", "CL")]
        [Route("listar-racas")]
        public ActionResult Index()
        {
            return View(_racaAppService.ObterTodos());
        }

        // GET: Racas/Details/5
        [ClaimsAuthorize("PermissoesCliente", "CD")]
        [Route("{id:guid}/detalhe-raca")]
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var racaViewModel = _racaAppService.ObterPorId(id.Value);

            if (racaViewModel == null)
            {
                return HttpNotFound();
            }
            return View(racaViewModel);
        }

        // GET: Racas/Create
        [ClaimsAuthorize("PermissoesCliente", "CI")]
        [Route("nova-raca")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Racas/Create
        [ClaimsAuthorize("PermissoesCliente", "CI")]
        [Route("nova-raca")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RacaViewModel racaViewModel)
        {
            if (ModelState.IsValid)
            {
                racaViewModel = _racaAppService.Adicionar(racaViewModel);

                if (!racaViewModel.ValidationResult.IsValid)
                {
                    foreach (var erro in racaViewModel.ValidationResult.Erros)
                    {
                        ModelState.AddModelError(string.Empty, erro.Message);
                    }
                    return View(racaViewModel);
                }
                return RedirectToAction("Index");
            }
            return View(racaViewModel);
        }

        // GET: Racas/Edit/5
        [ClaimsAuthorize("PermissoesCliente", "CE")]
        [Route("{id:guid}/editar-raca")]
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var racaViewModel = _racaAppService.ObterPorId(id.Value);

            if (racaViewModel == null)
            {
                return HttpNotFound();
            }
            return View(racaViewModel);
        }

        // POST: Racas/Edit/5
        [ClaimsAuthorize("PermissoesCliente", "CE")]
        [Route("{id:guid}/editar-raca")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RacaViewModel racaViewModel)
        {
            if (ModelState.IsValid)
            {
                _racaAppService.Atualizar(racaViewModel);
                return RedirectToAction("Index");
            }
            return View(racaViewModel);
        }

        // GET: Racas/Delete/5
        [ClaimsAuthorize("PermissoesCliente", "CX")]
        [Route("{id:guid}/excluir-raca")]
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var racaViewModel = _racaAppService.ObterPorId(id.Value);

            if (racaViewModel == null)
            {
                return HttpNotFound();
            }
            return View(racaViewModel);
        }

        // POST: Racas/Delete/5
        [ClaimsAuthorize("PermissoesCliente", "CX")]
        [Route("{id:guid}/excluir-raca")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _racaAppService.remover(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _racaAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
