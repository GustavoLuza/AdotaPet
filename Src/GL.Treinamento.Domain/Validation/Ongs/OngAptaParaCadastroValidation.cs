using DomainValidation.Validation;
using GL.Treinamento.Domain.Entities;
using GL.Treinamento.Domain.Interfaces.Repository;
using GL.Treinamento.Domain.Specifications.Ongs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GL.Treinamento.Domain.Validation.Ongs
{
    public class OngAptaParaCadastroValidation : Validator<Ong>
    {
        public OngAptaParaCadastroValidation(IOngRepository ongRepository)
        {
            var CNPJDuplicado = new OngDevePossuirCNPJUnicoSpecification(ongRepository);
            var EmailDuplicado = new OngDevePossuirEmaulUnicoSpecification(ongRepository);

            base.Add("CNPJDuplicado", new Rule<Ong>(CNPJDuplicado, "Atenção! CNPJ já cadastrado"));
            base.Add("EmailDuplicado", new Rule<Ong>(EmailDuplicado, "Atenção! E-mail já cadastrado"));
        }
    }
}
