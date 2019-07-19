using DomainValidation.Interfaces.Specification;
using GL.Treinamento.Domain.Entities;
using GL.Treinamento.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GL.Treinamento.Domain.Specifications.Racas
{
    public class RacaDeveSerUnicaSpecification :ISpecification<Raca>
    {
        private readonly IRacaRepository _racaRepository;

        public RacaDeveSerUnicaSpecification(IRacaRepository racaRepository)
        {
            _racaRepository = racaRepository;
        }

        public bool IsSatisfiedBy(Raca raca)
        {
            return _racaRepository.ObterPorRaca(raca.NomeRaca) == null;
        }
    }
}
