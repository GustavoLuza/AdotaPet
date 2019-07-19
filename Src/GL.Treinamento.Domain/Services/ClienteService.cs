using GL.Treinamento.Domain.Entities;
using GL.Treinamento.Domain.Interfaces.Services;
using GL.Treinamento.Domain.Validation.Clientes;
using GL.Treinamento.Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GL.Treinamento.Domain.Services
{
    public class ClienteService : IClienteService
    {
        //INJEÇÃO DE DEPENDENCIA
        private readonly IClienteRepository _clienteRepository; //REPOSITORIO PARA PERSISTIR O CLIENTE

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public Cliente Adicionar(Cliente cliente)
        {
            if (!cliente.IsValid())
                return cliente;

            cliente.ValidationResult = new ClienteAptoParaCadastroValidation(_clienteRepository).Validate(cliente); //VERIFICA SE O CPF E EMAIL ESTAO CADASTRDOS NA BASE
            if (!cliente.ValidationResult.IsValid)
                return cliente;

            return _clienteRepository.Adicionar(cliente);
        }

        public Cliente Atualizar(Cliente cliente)
        {
            return _clienteRepository.Atualizar(cliente);
        }

        public void Dispose()
        {
            _clienteRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public IEnumerable<Cliente> ObterAtivos()
        {
            return _clienteRepository.ObterAtivos();
        }

        public Cliente ObterPorCpf(string cpf)
        {
            return _clienteRepository.ObterPorCpf(cpf);
        }

        public Cliente ObterPorEmail(string email)
        {
            return _clienteRepository.ObterPorEmail(email);
        }

        public Cliente ObterPorId(Guid id)
        {
            return _clienteRepository.ObterPorId(id);
        }

        public IEnumerable<Cliente> ObterTodos()
        {
            return _clienteRepository.ObterTodos();
        }

        public void Remover(Guid id)
        {
            _clienteRepository.Remover(id);
        }
    }
}
