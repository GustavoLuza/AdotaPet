using DomainValidation.Validation;
using GL.Treinamento.Domain.Validation.Ongs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GL.Treinamento.Domain.Entities
{
    public class Ong
    {
        public Ong()
        {
            OngId = Guid.NewGuid();
            Enderecos = new List<Endereco>();
        }

        public Guid OngId { get; set; }
        public string NomeFantasia { get; set; }
        public string CNPJ { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCadastro { get; set; }
        public virtual ICollection<Endereco> Enderecos { get; set; }
        public Guid ClienteId { get; set; }
        public ValidationResult ValidationResult { get; set; }
        public bool IsValid()
        {
            ValidationResult = new OngEstaConsistenteValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
