using N.Treinamento.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N.Treinamento.Application.Interfaces
{
   public interface IAspNetUsersAppService : IDisposable
    {
        AspNetUsersViewModel ObterPorId(Guid id);
        IEnumerable<AspNetUsersViewModel> ObterTodos();
    }
}
