using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GL.Treinamento.UI.Site.Models;
using N.Treinamento.Application;
using N.Treinamento.Application.Interfaces;
using N.Treinamento.Application.ViewModels;

namespace GL.Treinamento.UI.Site.Controllers
{
    public class PainelAdministrativoController : Controller
    {
        private readonly IPainelAdministrativoAppService _painelAdministrativoAppService;

        private readonly IAspNetUsersAppService _aspNetUsersAppService;

        public PainelAdministrativoController(IPainelAdministrativoAppService painelAdministrativoAppService, IAspNetUsersAppService aspNetUsersAppService)
        {
            _painelAdministrativoAppService = painelAdministrativoAppService;

            _aspNetUsersAppService = aspNetUsersAppService;
        }

        // GET: PainelAdministrativo
        public ActionResult Index()
        {
            return View(_painelAdministrativoAppService.ObterTodos());
        }

        // GET: PainelAdministrativo/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            var painelAdm = _painelAdministrativoAppService.ObterPorInt(id);

            if (painelAdm == null)
            {
                return HttpNotFound();
            }
            return View(painelAdm);
        }

        // GET: PainelAdministrativo/Create
        public ActionResult Create()
        {
            ViewBag.VBUsuario = _aspNetUsersAppService.ObterTodos();
            return View();
        }

        // POST: PainelAdministrativo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PainelAdministrativoViewModel painelAdministrativoViewModel)
        {
            if (ModelState.IsValid)
            {
                painelAdministrativoViewModel = _painelAdministrativoAppService.Adicionar(painelAdministrativoViewModel);      
                //return RedirectToAction("Index");
            }
            return View(painelAdministrativoViewModel);
        }

        // GET: PainelAdministrativo/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var painelAdm = _painelAdministrativoAppService.ObterPorInt(id);

            if (painelAdm == null)
            {
                return HttpNotFound();
            }
            return View(painelAdm);
        }

        // POST: PainelAdministrativo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PainelAdministrativoViewModel painelAdministrativoViewModel)
        {
            if (ModelState.IsValid)
            {
                _painelAdministrativoAppService.Atualizar(painelAdministrativoViewModel);
                return RedirectToAction("Index");
            }
            return View(painelAdministrativoViewModel);
        }

        // GET: PainelAdministrativo/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var painelAdm = _painelAdministrativoAppService.ObterPorInt(id);

            if (painelAdm == null)
            {
                return HttpNotFound();
            }
            return View(painelAdm);
        }

        // POST: PainelAdministrativo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            return RedirectToAction("Index");
        }

        public JsonResult ObterUsuario()
        {
            return Json(_painelAdministrativoAppService.ObterTodos(), JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _painelAdministrativoAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
