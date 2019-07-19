using DomainValidation.Interfaces.Specification;
using GL.Treinamento.Domain.Entities;
using GL.Treinamento.Domain.Validation.Documentos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GL.Treinamento.Domain.Specifications.Ongs
{
    public class OngDeveTerEmailValidoSpecification : ISpecification<Ong>
    {
        public bool IsSatisfiedBy(Ong ong)
        {
            return EmailValidation.Validar(ong.Email);
        }
    }
}
