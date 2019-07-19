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
    [Authorize] //PARA FAZER ACESSO A CONTROLLER, PRECISA ESTAR LOGADO

    [RoutePrefix("gestao/cadastros")]
    public class ClientesController : Controller
    {
        //INJEÇÃO DE DEPENDENCIA
        private readonly IClienteAppService _clienteAppService;

        public ClientesController(IClienteAppService clienteAppService)
        {
            _clienteAppService = clienteAppService;
        }

        // GET: Clientes
        [ClaimsAuthorize("PermissoesCliente", "CL")]
        [Route("listar-pessoas")]
        public ActionResult Index()
        {
            return View(_clienteAppService.ObterTodos());
        }

        // GET: Clientes/Details/5
        [ClaimsAuthorize("PermissoesCliente", "CD")]
        [Route("{id:guid}/detalhe-pessoa")]
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var clienteViewModel = _clienteAppService.ObterPorId(id.Value);

            if (clienteViewModel == null)
            {
                return HttpNotFound();
            }
            return View(clienteViewModel);
        }

        // GET: Clientes/Create
        [ClaimsAuthorize("PermissoesCliente", "CI")]
        [Route("nova-pessoa")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        [ClaimsAuthorize("PermissoesCliente", "CI")]
        [Route("nova-pessoa")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteEnderecoViewModel clienteEnderecoViewModel)
        {
            if (ModelState.IsValid)
            {
              clienteEnderecoViewModel =  _clienteAppService.Adicionar(clienteEnderecoViewModel);

                if (!clienteEnderecoViewModel.ValidationResult.IsValid)
                {
                    foreach (var erro in clienteEnderecoViewModel.ValidationResult.Erros)
                    {
                        ModelState.AddModelError(string.Empty, erro.Message);
                    }
                    return View(clienteEnderecoViewModel); //CASO TENHA ALGUM ERRO RETORNA PARA A VIEW DE CADASTRO
                }
                return RedirectToAction("Index");
            }

            return View(clienteEnderecoViewModel);
        }

        // GET: Clientes/Edit/5
        [ClaimsAuthorize("PermissoesCliente", "CE")]
        [Route("{id:guid}/editar-pessoa")]
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var clienteViewModel = _clienteAppService.ObterPorId(id.Value);

            if (clienteViewModel == null)
            {
                return HttpNotFound();
            }
            return View(clienteViewModel);
        }

        // POST: Clientes/Edit/5
        [ClaimsAuthorize("PermissoesCliente", "CE")]
        [Route("{id:guid}/editar-pessoa")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClienteViewModel clienteViewModel)
        {
            if (ModelState.IsValid)
            {
                _clienteAppService.Atualizar(clienteViewModel);
                return RedirectToAction("Index");
            }
            return View(clienteViewModel);
        }

        // GET: Clientes/Delete/5
        [ClaimsAuthorize("PermissoesCliente", "CX")]
        [Route("{id:guid}/excluir-pessoa")]
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var clienteViewModel = _clienteAppService.ObterPorId(id.Value);

            if (clienteViewModel == null)
            {
                return HttpNotFound();
            }
            return View(clienteViewModel);
        }

        // POST: Clientes/Delete/5
        [ClaimsAuthorize("PermissoesCliente", "CX")]
        [Route("{id:guid}/excluir-pessoa")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _clienteAppService.remover(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _clienteAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
