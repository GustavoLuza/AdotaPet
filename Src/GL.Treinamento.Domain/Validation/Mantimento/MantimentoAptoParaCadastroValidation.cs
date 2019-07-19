using DomainValidation.Validation;
using GL.Treinamento.Domain.Entities;
using GL.Treinamento.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GL.Treinamento.Domain.Validation.Mantimento
{
    public class MantimentoAptoParaCadastroValidation :Validator<Mantimentos>
    {
        public MantimentoAptoParaCadastroValidation(IMantimentoRepository mantimentoRepository)
        {

        }
    }
}
