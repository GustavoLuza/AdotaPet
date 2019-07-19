using DomainValidation.Interfaces.Specification;
using GL.Treinamento.Domain.Entities;
using GL.Treinamento.Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GL.Treinamento.Domain.Specifications.Clientes
{
   public class ClienteDevePossuirEmailUnicoSpecification :ISpecification<Cliente>
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteDevePossuirEmailUnicoSpecification(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public bool IsSatisfiedBy(Cliente cliente)
        {
            return _clienteRepository.ObterPorEmail(cliente.Email) == null;
        }
    }
}
