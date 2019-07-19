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
    public class RacaAppService :AppService, IRacaAppService
    {
        private readonly IRacaService _racaService;

        public RacaAppService(IRacaService racaService, IUnityOfWork uow) :base (uow)
        {
            _racaService = racaService;
        }

        public RacaViewModel Adicionar(RacaViewModel racaViewModel)
        {
            var raca = Mapper.Map<Raca>(racaViewModel);

            var racaReturn = _racaService.Adicionar(raca);

            if (racaReturn.ValidationResult.IsValid)
            {
                Commit();
            }

            return Mapper.Map<RacaViewModel>(racaReturn);
        }

        public RacaViewModel Atualizar(RacaViewModel racaViewModel)
        {
            var raca = Mapper.Map<Raca>(racaViewModel);
            _racaService.Atualizar(raca);
            Commit();
            return racaViewModel;
        }

        public void Dispose()
        {
            _racaService.Dispose();
            GC.SuppressFinalize(this);
        }

        public RacaViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<RacaViewModel>(_racaService.ObterPorId(id));
        }

        public RacaViewModel ObterPorRaca(string nomeRaca)
        {
            return Mapper.Map<RacaViewModel>(_racaService.ObterPorRaca(nomeRaca));
        }

        public IEnumerable<RacaViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<RacaViewModel>>(_racaService.ObterTodos().ToList());
        }

        public void remover(Guid id)
        {
            _racaService.Remover(id);
            Commit();
        }
    }
}
