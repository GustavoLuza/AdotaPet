using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GL.Treinamento.Domain.Interfaces.Services;
using GL.Treinamento.Infra.CrossCutting.MvcFilters;
using GL.Treinamento.UI.Site.Models;
using N.Treinamento.Application.Interfaces;
using N.Treinamento.Application.ViewModels;

namespace GL.Treinamento.UI.Site.Controllers
{
    [Authorize]
    [RoutePrefix("gestao/cadastros")]
    public class AnimaisController : Controller
    {
        private readonly IAnimalAppService _animalAppService;

        private readonly IDoencaAppService _doencaAppService;

        private readonly IRacaAppService _racaAppService;

        public AnimaisController(IAnimalAppService animalAppService, IDoencaAppService doencaAppService, IRacaAppService racaAppService)
        {
            _animalAppService = animalAppService;

            _doencaAppService = doencaAppService;

            _racaAppService = racaAppService;
        }

        // GET: Animais
        [ClaimsAuthorize("PermissoesCliente", "CL")]
        [Route("listar-animais")]
        public ActionResult Index()
        {
            return View(_animalAppService.ObterTodos());
        }

        // GET: Animais/Details/5
        [ClaimsAuthorize("PermissoesCliente", "CD")]
        [Route("{id:guid}/detalhe-animal")]
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var animalViewModel = _animalAppService.ObterPorId(id.Value);

            if (animalViewModel == null)
            {
                return HttpNotFound();
            }
            return View(animalViewModel);
        }

        // GET: Animais/Create
        [ClaimsAuthorize("PermissoesCliente", "CI")]
        [Route("novo-animal")]
        public ActionResult Create()
        {
            ViewBag.VBDoenca = _doencaAppService.ObterTodos();

            ViewBag.VBRaca = _racaAppService.ObterTodos();

            return View();
        }

        // POST: Animais/Create
        [ClaimsAuthorize("PermissoesCliente", "CI")]
        [Route("novo-animal")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AnimalViewModel animalViewModel)
        {
            if (ModelState.IsValid)
            {
                animalViewModel = _animalAppService.Adicionar(animalViewModel);

                if (!animalViewModel.ValidationResult.IsValid)
                {
                    foreach (var erro in animalViewModel.ValidationResult.Erros)
                    {
                        ModelState.AddModelError(string.Empty, erro.Message);
                    }
                    return View(animalViewModel); //CASO TENHA ALGUM ERRO RETORNA PARA A VIEW DE CADASTRO
                }
                return RedirectToAction("Index");
            }

            return View(animalViewModel);
        }

        // GET: Animais/Edit/5
        [ClaimsAuthorize("PermissoesCliente", "CE")]
        [Route("{id:guid}/editar-animal")]
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.VBDoenca = _doencaAppService.ObterTodos();

            ViewBag.VBRaca = _racaAppService.ObterTodos();
            var animalViewModel = _animalAppService.ObterPorId(id.Value);

            if (animalViewModel == null)
            {
                return HttpNotFound();
            }
            return View(animalViewModel);
        }

        // POST: Animais/Edit/5
        [ClaimsAuthorize("PermissoesCliente", "CE")]
        [Route("{id:guid}/editar-animal")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( AnimalViewModel animalViewModel)
        {
            if (ModelState.IsValid)
            {
                _animalAppService.Atualizar(animalViewModel);
                return RedirectToAction("Index");
            }
            return View(animalViewModel);
        }

        // GET: Animais/Delete/5
        [ClaimsAuthorize("PermissoesCliente", "CX")]
        [Route("{id:guid}/excluir-animal")]
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var animalViewModel = _animalAppService.ObterPorId(id.Value);

            if (animalViewModel == null)
            {
                return HttpNotFound();
            }
            return View(animalViewModel);
        }

        // POST: Animais/Delete/5
        [ClaimsAuthorize("PermissoesCliente", "CX")]
        [Route("{id:guid}/excluir-animal")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _animalAppService.Remover(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _animalAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
