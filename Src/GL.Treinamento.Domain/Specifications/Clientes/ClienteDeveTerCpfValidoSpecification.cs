using DomainValidation.Interfaces.Specification;
using GL.Treinamento.Domain.Entities;
using GL.Treinamento.Domain.Validation.Documentos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GL.Treinamento.Domain.Specifications.Clientes
{
    public class ClienteDeveTerCpfValidoSpecification : ISpecification<Cliente>
    {
        public bool IsSatisfiedBy(Cliente cliente)
        {
            return CPFValidation.Validar(cliente.CPF);
        }
    }
}
