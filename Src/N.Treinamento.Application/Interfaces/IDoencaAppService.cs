using N.Treinamento.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N.Treinamento.Application.Interfaces
{
    public interface IDoencaAppService :IDisposable
    {
        DoencaViewModel Adicionar(DoencaViewModel doencaViewModel);
        DoencaViewModel ObterPorId(Guid id);
        IEnumerable<DoencaViewModel> ObterTodos();
        DoencaViewModel Atualizar(DoencaViewModel doencaViewModel);
        DoencaViewModel ObterPorDoenca(string nomeDoenca);
        void remover(Guid id);
    }
}
