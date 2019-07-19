using DomainValidation.Validation;
using GL.Treinamento.Domain.Validation.Racas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GL.Treinamento.Domain.Entities
{
    public class Raca
    {
        public Raca()
        {
            RacaId = Guid.NewGuid();
        }

        public Guid RacaId { get; set; }
        public string NomeRaca { get; set; }
        public ValidationResult ValidationResult { get; set; }
        public bool IsValid()
        {
            ValidationResult = new RacaEstaConsistenteValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
