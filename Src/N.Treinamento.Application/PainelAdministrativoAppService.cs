using AutoMapper;
using GL.Treinamento.Domain.Entities;
using GL.Treinamento.Domain.Interfaces.Services;
using GL.Treinamento.Infra.Data.UnitOfWork;
using N.Treinamento.Application.Interfaces;
using N.Treinamento.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N.Treinamento.Application
{
   public class PainelAdministrativoAppService :AppService, IPainelAdministrativoAppService
    {
        private readonly IPainelAdministrativoService _painelAdministrativoService;

        public PainelAdministrativoAppService(IPainelAdministrativoService painelAdministrativoService, IUnityOfWork uow) : base(uow)
        {
            _painelAdministrativoService = painelAdministrativoService;
        }

        public PainelAdministrativoViewModel Adicionar(PainelAdministrativoViewModel painelAdministrativo)
        {
            var painelAdm = Mapper.Map<PainelAdministrativo>(painelAdministrativo);

            // var painelReturn = _painelAdministrativoService.Adicionar(painelAdm);   //TALVEZ PRECISE IMPLEMENTAR O VALIDATION RESULT

            Commit();

            return Mapper.Map<PainelAdministrativoViewModel>(painelAdm);
        }

        public PainelAdministrativoViewModel Atualizar(PainelAdministrativoViewModel painelAdministrativo)
        {
            var painel = Mapper.Map<PainelAdministrativo>(painelAdministrativo);
            _painelAdministrativoService.Atualizar(painel);
            Commit();
            return painelAdministrativo;
        }

        public void Dispose()
        {
            _painelAdministrativoService.Dispose();
            GC.SuppressFinalize(this);
        }

        public PainelAdministrativoViewModel ObterPorInt(int id)
        {
            return Mapper.Map<PainelAdministrativoViewModel>(_painelAdministrativoService.ObterPorInt(id));
        }

        public IEnumerable<PainelAdministrativoViewModel> ObterTodos()
        {
            return Mapper.Map<List<PainelAdministrativoViewModel>>(_painelAdministrativoService.ObterTodos().ToList());   //PAROU DE FUNCIONAR NAO SEI PQ
        }
    }
}
