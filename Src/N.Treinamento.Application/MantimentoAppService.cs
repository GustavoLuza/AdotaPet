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
            throw new NotImplementedException();
        }

        public MantimentoViewModel Atualizar(MantimentoViewModel mantimentoViewModel)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public MantimentoViewModel ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MantimentoViewModel> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public void Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
