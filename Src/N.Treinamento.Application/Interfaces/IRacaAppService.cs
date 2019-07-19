using N.Treinamento.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N.Treinamento.Application.Interfaces
{
    public interface IRacaAppService :IDisposable
    {
        RacaViewModel Adicionar(RacaViewModel racaViewModel);
        RacaViewModel ObterPorId(Guid id);
        IEnumerable<RacaViewModel> ObterTodos();
        RacaViewModel Atualizar(RacaViewModel racaViewModel);
        RacaViewModel ObterPorRaca(string nomeRaca);
        void remover(Guid id);
    }
}
