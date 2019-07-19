using DomainValidation.Validation;
using GL.Treinamento.Domain.Validation.Doencas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GL.Treinamento.Domain.Entities
{
    public class Doenca
    {
        public Doenca()
        {
            DoencaId = Guid.NewGuid();    
        }

        public Guid DoencaId { get; set; }
        public string NomeDoenca { get; set; }
        public ValidationResult ValidationResult { get; set; }
        public bool IsValid()
        {
            ValidationResult = new DoencaEstaConsistenteValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
