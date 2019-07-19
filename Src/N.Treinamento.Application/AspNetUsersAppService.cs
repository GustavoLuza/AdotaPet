using AutoMapper;
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
   public class AspNetUsersAppService :AppService, IAspNetUsersAppService
    {
        private readonly IAspNetUsersService _aspNetUsersService;

        public AspNetUsersAppService(IAspNetUsersService aspNetUsersService, IUnityOfWork uow) : base(uow)
        {
            _aspNetUsersService = aspNetUsersService;
        }

        public void Dispose()
        {
            _aspNetUsersService.Dispose();
            GC.SuppressFinalize(this);
        }

        public AspNetUsersViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<AspNetUsersViewModel>(_aspNetUsersService.ObterPorId(id));
        }

        public IEnumerable<AspNetUsersViewModel> ObterTodos()
        {
            return Mapper.Map<List<AspNetUsersViewModel>>(_aspNetUsersService.ObterTodos());
        }
    }
}
