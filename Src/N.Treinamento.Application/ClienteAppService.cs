using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using GL.Treinamento.Domain.Entities;
using GL.Treinamento.Domain.Interfaces.Services;
using GL.Treinamento.Infra.Data.UnitOfWork;
using N.Treinamento.Application.ViewModels;

namespace N.Treinamento.Application.Interfaces
{
    public class ClienteAppService : AppService, IClienteAppService // IMPLEMENTAÇÃO DO IClienteAppService
    {

        //INJEÇÃO DE DEPENDENCIA
        private readonly IClienteService _clienteService;

        public ClienteAppService(IClienteService clienteService, IUnityOfWork uow) :base(uow)
        {
            _clienteService =  clienteService;  //_clienteService RECEBE UMA INSTANCIA DO clienteService
        }

        public ClienteEnderecoViewModel Adicionar(ClienteEnderecoViewModel clienteEnderecoViewModel)
        {
            var cliente = Mapper.Map<Cliente>(clienteEnderecoViewModel);  //TRANSFORMAR O ClienteEnderecoViewModel EM UM CLIENTE
            var endereco = Mapper.Map<Endereco>(clienteEnderecoViewModel); //TRANSFORMAR O ClienteEnderecoViewModel EM UM ENDERECO

            cliente.Enderecos.Add(endereco);

           var clienteReturn = _clienteService.Adicionar(cliente);

            //VERIFICAR SE O DOMINIO NÃO CRITICOU NADA
            if(clienteReturn.ValidationResult.IsValid)
            {
                cliente.Ativo = true;  //gambi
                Commit();
            }

            return Mapper.Map<ClienteEnderecoViewModel>(clienteReturn);
        }

        public ClienteViewModel Atualizar(ClienteViewModel clienteViewModel)
        {
            var cliente = Mapper.Map<Cliente>(clienteViewModel);
            _clienteService.Atualizar(cliente);
            cliente.Ativo = true;  //gambi
            Commit(); //gambi
            return clienteViewModel;
        }

        public ClienteViewModel ObterPorCpf(string cpf)
        {
            return Mapper.Map<ClienteViewModel>(_clienteService.ObterPorCpf(cpf));
        }

        public ClienteViewModel ObterPorEmail(string email)
        {
            return Mapper.Map<ClienteViewModel>(_clienteService.ObterPorEmail(email));
        }

        public ClienteViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<ClienteViewModel>(_clienteService.ObterPorId(id));
        }

        public IEnumerable<ClienteViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<ClienteViewModel>>(_clienteService.ObterAtivos().ToList());
        }

        public void remover(Guid id)
        {
            _clienteService.Remover(id);
            Commit();  //NÃO SEI SE DEVERIA ESTAR AQUI
        }

        public void Dispose()
        {
            _clienteService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
