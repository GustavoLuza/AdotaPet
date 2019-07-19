using GL.Treinamento.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GL.Treinamento.Domain.Interfaces.Services
{
   public interface IAspNetUsersService :IDisposable
    {
        AspNetUsers ObterPorId(Guid id);
        IEnumerable<AspNetUsers> ObterTodos();
    }
}
