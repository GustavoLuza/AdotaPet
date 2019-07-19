using DomainValidation.Interfaces.Specification;
using GL.Treinamento.Domain.Entities;
using GL.Treinamento.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GL.Treinamento.Domain.Specifications.Doencas
{
    public class DoencaDeveSerUnicaSpecification : ISpecification<Doenca>
    {
        private readonly IDoencaRepository _doencaRepository;

        public DoencaDeveSerUnicaSpecification(IDoencaRepository doencaRepository)
        {
            _doencaRepository = doencaRepository;
        }
        public bool IsSatisfiedBy(Doenca doenca)
        {
            return _doencaRepository.ObterPorDoenca(doenca.NomeDoenca) == null;
        }
    }
}
