using DomainValidation.Validation;
using GL.Treinamento.Domain.Entities;
using GL.Treinamento.Domain.Specifications.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GL.Treinamento.Domain.Validation.Clientes
{
    public class ClienteEstaConsistenteValidation : Validator<Cliente>
    {
        public ClienteEstaConsistenteValidation()
        {
            var CPFCliente = new ClienteDeveTerCpfValidoSpecification();
            var clienteEmail = new ClienteDeveTerEmailValidoSpecification();
            var clienteMaioridade = new ClienteDeveSerMaiorDeIdadeSpecification();

            base.Add("CPFCliente", new Rule<Cliente>(CPFCliente, "Cliente informou um CPF inválido."));
            base.Add("clienteEmail", new Rule<Cliente>(clienteEmail, "Cliente informou um e-mail inválido."));
            base.Add("clienteMaioridade", new Rule<Cliente>(clienteMaioridade, "Cliente não tem maioridade para cadastro."));
        }
    }
}
