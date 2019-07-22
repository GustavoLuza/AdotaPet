using GL.Treinamento.Domain.Enum;
using DomainValidation.Validation;
using GL.Treinamento.Domain.Validation.Mantimento;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GL.Treinamento.Domain.Entities
{
    public class Mantimentos
    {
        public Mantimentos()
        {
            MantimentoId = Guid.NewGuid();
        }

        public Guid MantimentoId { get; set; }
        public Guid OngId { get; set; }
        public string Descricao { get; set; }
        public int CodigoIdentificacao { get; set; }
        public DateTime DataValidade { get; set; }
        public DateTime DataCadastro { get; set; }
        public Enums.DescricaoMantimentos Item { get; set; }
        public Enums.Quantidade Quantidade { get; set; }
        public Enums.TipoMantimento Tipo { get; set; }
        public bool Ativo { get; set; }
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }
        public bool IsValid()
        {
            ValidationResult = new MantimentoEstaConsistenteValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
