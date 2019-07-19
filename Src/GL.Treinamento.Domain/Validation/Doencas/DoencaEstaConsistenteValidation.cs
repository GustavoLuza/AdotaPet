using DomainValidation.Validation;
using GL.Treinamento.Domain.Entities;
using GL.Treinamento.Domain.Specifications.Doencas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GL.Treinamento.Domain.Validation.Doencas
{
    public class DoencaEstaConsistenteValidation : Validator <Doenca>
    {
        public DoencaEstaConsistenteValidation()
        {
            
        }
    }
}
