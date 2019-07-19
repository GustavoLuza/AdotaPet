using DomainValidation.Validation;
using GL.Treinamento.Domain.Entities;
using GL.Treinamento.Domain.Interfaces.Repository;
using GL.Treinamento.Domain.Specifications.Racas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GL.Treinamento.Domain.Validation.Racas
{
    public class RacaAptaParaCadastroValidation :Validator<Raca>
    {
        public RacaAptaParaCadastroValidation(IRacaRepository racaRepository)
        {
            var racaDuplicada = new RacaDeveSerUnicaSpecification(racaRepository);

            base.Add("racaDuplicada", new Rule<Raca>(racaDuplicada, "Atenção! Raça já cadastrada"));
        }
    }
}
