using DomainValidation.Validation;
using GL.Treinamento.Domain.Entities;
using GL.Treinamento.Domain.Interfaces.Repository;
using GL.Treinamento.Domain.Specifications.Doencas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GL.Treinamento.Domain.Validation.Doencas
{
    public class DoencaAptaParaCadastroValidation :Validator<Doenca>
    {
        public DoencaAptaParaCadastroValidation(IDoencaRepository doencaRepository )
        {
            var doencaDuplicada = new DoencaDeveSerUnicaSpecification(doencaRepository);

            base.Add("doencaDuplicada", new Rule<Doenca>(doencaDuplicada, "Atenção! Doença já cadstrada"));
        }
    }
}
