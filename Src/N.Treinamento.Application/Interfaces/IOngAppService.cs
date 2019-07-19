using N.Treinamento.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N.Treinamento.Application.Interfaces
{
    public interface IOngAppService :IDisposable
    {
        OngEnderecoViewModel Adicionar(OngEnderecoViewModel ongEnderecoViewModel);
        OngViewModel ObterPorId(Guid id);
        IEnumerable<OngViewModel> ObterTodos();
        OngViewModel ObterPorCNPJ(string cnpj);
        OngViewModel ObterPorEmail(string email);
        OngViewModel Atualizar(OngViewModel ongViewModel);
        void remover(Guid id);
    }
}
