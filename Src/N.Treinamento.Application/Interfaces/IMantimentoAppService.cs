using N.Treinamento.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N.Treinamento.Application.Interfaces
{
    public interface IMantimentoAppService :IDisposable
    {
        MantimentoViewModel Adicionar(MantimentoViewModel mantimentoViewModel);
        MantimentoViewModel ObterPorId(Guid id);
        IEnumerable<MantimentoViewModel> ObterTodos();
        MantimentoViewModel Atualizar(MantimentoViewModel mantimentoViewModel);
        void Remover(Guid id);
    }
}
