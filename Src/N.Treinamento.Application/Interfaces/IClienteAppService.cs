using N.Treinamento.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N.Treinamento.Application.Interfaces
{
    //AQUI CONSTA O QUE A CAMADA DE APLICAÇÃO VAI OFERECER PARA A CAMADA DE APRESENTAÇÃO
   public interface IClienteAppService : IDisposable // DEPOIS DO : É FEITA A IMPLEMENTAÇÃO DO IDisposable
    {
        ClienteEnderecoViewModel Adicionar(ClienteEnderecoViewModel clienteEnderecoViewModel);
        ClienteViewModel ObterPorId(Guid id);
        IEnumerable<ClienteViewModel> ObterTodos();
        ClienteViewModel ObterPorCpf(string cpf);
        ClienteViewModel ObterPorEmail(string email);
        ClienteViewModel Atualizar(ClienteViewModel clienteViewModel);
        void remover(Guid id);
    }
}

