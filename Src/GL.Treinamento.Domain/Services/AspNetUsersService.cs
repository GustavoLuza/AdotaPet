using GL.Treinamento.Domain.Entities;
using GL.Treinamento.Domain.Interfaces.Repository;
using GL.Treinamento.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GL.Treinamento.Domain.Services
{
    public class AspNetUsersService : IAspNetUsersService
    {

        private readonly IAspNetUsersRepository _aspNetUsersRepository;

        public AspNetUsersService(IAspNetUsersRepository aspNetUsersRepository)
        {
            _aspNetUsersRepository = aspNetUsersRepository;
        }

        public void Dispose()
        {
            _aspNetUsersRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public AspNetUsers ObterPorId(Guid id)
        {
            return _aspNetUsersRepository.ObterPorId(id);
        }

        public IEnumerable<AspNetUsers> ObterTodos()
        {
            return _aspNetUsersRepository.ObterTodos();
        }
    }
}
