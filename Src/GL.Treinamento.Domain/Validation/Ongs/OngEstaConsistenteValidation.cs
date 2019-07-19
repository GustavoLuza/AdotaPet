using DomainValidation.Validation;
using GL.Treinamento.Domain.Entities;
using GL.Treinamento.Domain.Specifications.Ongs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GL.Treinamento.Domain.Validation.Ongs
{
    public class OngEstaConsistenteValidation :Validator<Ong>
    {
        public OngEstaConsistenteValidation()
        {
            var CNPJOng = new OngDeveTerEmailValidoSpecification();
            var EmailOng = new OngDeveTerEmailValidoSpecification();

            base.Add("CNPJOng", new Rule<Ong>(CNPJOng, "ONG informou um CNPJ inválido."));
            base.Add("EmailOng", new Rule<Ong>(EmailOng, "ONG informou um E-mail inválido."));
        }
    }
}
