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
    public class MantimentoAppService :AppService, IMantimentoAppService
    {
        private readonly IMantimentoService _mantimentoService;

        public MantimentoAppService(IMantimentoService mantimentoService, IUnityOfWork uow) :base(uow)
        {
            _mantimentoService = mantimentoService;
        }

        public MantimentoViewModel Adicionar(MantimentoViewModel mantimentoViewModel)
        {
            var mantimento = Mapper.Map<Mantimentos>(mantimentoViewModel);

            var mantimentoreturn = _mantimentoService.Adicionar(mantimento);

            if(mantimentoreturn.ValidationResult.IsValid)
            {
                mantimento.Ativo = true;
                Commit();
            }

            return Mapper.Map<MantimentoViewModel>(mantimentoreturn);
        }

        public MantimentoViewModel Atualizar(MantimentoViewModel mantimentoViewModel)
        {
            var mantimento = Mapper.Map<Mantimentos>(mantimentoViewModel);
            _mantimentoService.Atualizar(mantimento);
            mantimento.Ativo = true;
            Commit();
            return mantimentoViewModel;
        }

        public void Dispose()
        {
            _mantimentoService.Dispose();
            GC.SuppressFinalize(this);
        }

        public MantimentoViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<MantimentoViewModel>(_mantimentoService.ObterPorId(id));
        }

        public IEnumerable<MantimentoViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<MantimentoViewModel>>(_mantimentoService.ObterAtivos().ToList());
        }

        public void Remover(Guid id)
        {
            _mantimentoService.Remover(id);
            Commit();
        }
    }
}
