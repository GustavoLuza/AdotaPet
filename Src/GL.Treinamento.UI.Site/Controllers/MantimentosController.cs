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
using Microsoft.AspNet.Identity;
using N.Treinamento.Application.Interfaces;
using N.Treinamento.Application.ViewModels;

namespace GL.Treinamento.UI.Site.Controllers
{
    [Authorize]
    [RoutePrefix("gestao/cadastros")]
    public class MantimentosController : Controller
    {
        private readonly IMantimentoAppService _mantimentoAppService;

        private readonly IOngAppService _ongAppService;

        public MantimentosController(IMantimentoAppService mantimentoAppService, IOngAppService ongAppService)
        {
            _mantimentoAppService = mantimentoAppService;
            _ongAppService = ongAppService;
        }
        // GET: Mantimentos
        [ClaimsAuthorize("PermissoesCliente", "CL")]
        [Route("listar-mantimentos")]
        public ActionResult Index()
        {
            return View(_mantimentoAppService.ObterTodos());
        }

        // GET: Mantimentos/Details/5
        [ClaimsAuthorize("PermissoesCliente", "CD")]
        [Route("{id:guid}/detalhe-mantimento")]
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var mantimentoViewModel = _mantimentoAppService.ObterPorId(id.Value);

            if (mantimentoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(mantimentoViewModel);
        }

        // GET: Mantimentos/Create
        [ClaimsAuthorize("PermissoesCliente", "CI")]
        [Route("novo-mantimento")]
        public ActionResult Create()
        {
            //User.Identity.GetUserId();
            ViewBag.VBOng = _ongAppService.ObterTodos();
            return View();
        }

        [ClaimsAuthorize("PermissoesCliente", "CI")]
        [Route("novo-mantimento")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MantimentoViewModel mantimentoViewModel)
        {
            if (ModelState.IsValid)
            {
                mantimentoViewModel = _mantimentoAppService.Adicionar(mantimentoViewModel);

                if (!mantimentoViewModel.ValidationResult.IsValid)
                {
                    foreach (var erro in mantimentoViewModel.ValidationResult.Erros)
                    {
                        ModelState.AddModelError(string.Empty, erro.Message);
                    }
                    return View(mantimentoViewModel); //CASO TENHA ALGUM ERRO RETORNA PARA A VIEW DE CADASTRO
                }
                return RedirectToAction("Index");
            }

            return View(mantimentoViewModel);
        }

        // GET: Mantimentos/Edit/5
        [ClaimsAuthorize("PermissoesCliente", "CE")]
        [Route("{id:guid}/editar-mantimento")]
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var mantimentoViewModel = _mantimentoAppService.ObterPorId(id.Value);

            if (mantimentoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(mantimentoViewModel);
        }

        [ClaimsAuthorize("PermissoesCliente", "CE")]
        [Route("{id:guid}/editar-mantimento")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MantimentoViewModel mantimentoViewModel)
        {
            if (ModelState.IsValid)
            {
                _mantimentoAppService.Atualizar(mantimentoViewModel);
                return RedirectToAction("Index");
            }
            return View(mantimentoViewModel);
        }

        // GET: Mantimentos/Delete/5
        [ClaimsAuthorize("PermissoesCliente", "CX")]
        [Route("{id:guid}/excluir-mantimento")]
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var mantimentoViewModel = _mantimentoAppService.ObterPorId(id.Value);

            if (mantimentoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(mantimentoViewModel);
        }

        // POST: Mantimentos/Delete/5
        [ClaimsAuthorize("PermissoesCliente", "CX")]
        [Route("{id:guid}/excluir-mantimento")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _mantimentoAppService.Remover(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _mantimentoAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
