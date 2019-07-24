using DomainValidation.Interfaces.Specification;
using GL.Treinamento.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GL.Treinamento.Domain.Specifications.Mantimento
{
    public class MantimentoDeveEstarDentroDaValidadeSpecification : ISpecification<Mantimentos>
    {
        public bool IsSatisfiedBy(Mantimentos mantimentos)
        {
            /* DateTime validade = Convert.ToDateTime(mantimentos.DataValidade);
             return DateTime.Now - validade >= DateTime.Now;*/
            return true;
        }
    }
}
