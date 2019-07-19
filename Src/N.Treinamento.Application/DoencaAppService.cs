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
    public class DoencaAppService : AppService, IDoencaAppService
    {
        private readonly IDoencaService _doencaService;

        public DoencaAppService(IDoencaService doencaService, IUnityOfWork uow) :base(uow)
        {
            _doencaService = doencaService;
        }

        public DoencaViewModel Adicionar(DoencaViewModel doencaViewModel)
        {
            var doenca = Mapper.Map<Doenca>(doencaViewModel);

            var doencaReturn = _doencaService.Adicionar(doenca);

            if(doencaReturn.ValidationResult.IsValid)
            {
                Commit();
            }

            return Mapper.Map<DoencaViewModel>(doencaReturn);
        }

        public DoencaViewModel Atualizar(DoencaViewModel doencaViewModel)
        {
            var doenca = Mapper.Map<Doenca>(doencaViewModel);
            _doencaService.Atualizar(doenca);
            Commit();
            return doencaViewModel;
        }

        public void Dispose()
        {
            _doencaService.Dispose();
            GC.SuppressFinalize(this);
        }

        public DoencaViewModel ObterPorDoenca(string nomeDoenca)
        {
            return Mapper.Map<DoencaViewModel>(_doencaService.ObterPorDoenca(nomeDoenca));
        }

        public DoencaViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<DoencaViewModel>(_doencaService.ObterPorId(id));
        }

        public IEnumerable<DoencaViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<DoencaViewModel>>(_doencaService.ObterTodos().ToList());
        }

        public void remover(Guid id)
        {
            _doencaService.Remover(id);
            Commit();
        }
    }
}
