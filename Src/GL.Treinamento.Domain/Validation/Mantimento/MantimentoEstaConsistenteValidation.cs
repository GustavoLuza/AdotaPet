using DomainValidation.Validation;
using GL.Treinamento.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GL.Treinamento.Domain.Validation.Mantimento
{
    public class MantimentoEstaConsistenteValidation : Validator<Mantimentos>
    {
        public MantimentoEstaConsistenteValidation()
        {
            
        }
    }
}
