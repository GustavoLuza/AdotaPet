using DomainValidation.Interfaces.Specification;
using GL.Treinamento.Domain.Entities;
using GL.Treinamento.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GL.Treinamento.Domain.Specifications.Ongs
{
    public class OngDevePossuirCNPJUnicoSpecification : ISpecification<Ong>
    {
        private readonly IOngRepository _ongRepository;

        public OngDevePossuirCNPJUnicoSpecification(IOngRepository ongRepository)
        {
            _ongRepository = ongRepository;
        }
        public bool IsSatisfiedBy(Entities.Ong ong)
        {
            return _ongRepository.ObterPorCNPJ(ong.CNPJ) == null;
        }
    }
}
