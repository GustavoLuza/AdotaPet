using DomainValidation.Validation;
using GL.Treinamento.Domain.Entities;
using GL.Treinamento.Domain.Specifications.Clientes;
using GL.Treinamento.Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GL.Treinamento.Domain.Validation.Clientes
{
   public class ClienteAptoParaCadastroValidation : Validator<Cliente>
    {

        public ClienteAptoParaCadastroValidation(IClienteRepository clienteRepository)
        {
            var cpfDuplicado = new ClienteDevePossuirCPFUnicoSpecification(clienteRepository);
            var emailDuplicado = new ClienteDevePossuirEmailUnicoSpecification(clienteRepository);

            base.Add("cpfDuplicado", new Rule<Cliente>(cpfDuplicado, "Atenção! CPF já cadastrado"));
            base.Add("emailDuplicado", new Rule<Cliente>(emailDuplicado, "Atenção! E-mail já cadastrado "));
        }
    }
}
