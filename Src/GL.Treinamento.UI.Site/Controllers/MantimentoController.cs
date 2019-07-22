using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GL.Treinamento.UI.Site.Models;
using N.Treinamento.Application.ViewModels;

namespace GL.Treinamento.UI.Site.Controllers
{
    public class MantimentoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Mantimento
        public ActionResult Index()
        {
            return View(db.MantimentoViewModels.ToList());
        }

        // GET: Mantimento/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MantimentoViewModel mantimentoViewModel = db.MantimentoViewModels.Find(id);
            if (mantimentoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(mantimentoViewModel);
        }

        // GET: Mantimento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Mantimento/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MantimentoId,OngId,Descricao,CodigoIdentificacao,DataValidade,DataCadastro,Item,Quantidade,Tipo,Ativo,ValidationResult")] MantimentoViewModel mantimentoViewModel)
        {
            if (ModelState.IsValid)
            {
                mantimentoViewModel.MantimentoId = Guid.NewGuid();
                db.MantimentoViewModels.Add(mantimentoViewModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mantimentoViewModel);
        }

        // GET: Mantimento/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MantimentoViewModel mantimentoViewModel = db.MantimentoViewModels.Find(id);
            if (mantimentoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(mantimentoViewModel);
        }

        // POST: Mantimento/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MantimentoId,OngId,Descricao,CodigoIdentificacao,DataValidade,DataCadastro,Item,Quantidade,Tipo,Ativo,ValidationResult")] MantimentoViewModel mantimentoViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mantimentoViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mantimentoViewModel);
        }

        // GET: Mantimento/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MantimentoViewModel mantimentoViewModel = db.MantimentoViewModels.Find(id);
            if (mantimentoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(mantimentoViewModel);
        }

        // POST: Mantimento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            MantimentoViewModel mantimentoViewModel = db.MantimentoViewModels.Find(id);
            db.MantimentoViewModels.Remove(mantimentoViewModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
