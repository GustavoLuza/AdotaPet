using DomainValidation.Validation;
using GL.Treinamento.Domain.Enum;
using GL.Treinamento.Domain.Validation.Animais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GL.Treinamento.Domain.Entities
{
    public class Animal
    {
        public Animal()
        {
            AnimalId = Guid.NewGuid();
        }

        public Guid AnimalId { get; set; }
        public string NomeAnimal { get; set; }
        public Enums.CorPelagem CorPelagem { get; set; }
        public Enums.EspecieAnimal Especie { get; set; }
        public Guid DoencaId { get; set; }
        public Guid RacaId { get; set; }
        public Enums.SexoAnimais Sexo { get; set; }
        public Enums.RespostasSimNao Castrado { get; set; }
        public string Vermifugado { get; set; }
        public string Vacinado { get; set; }
        public Enums.PorteAnimal Porte { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCadastro { get; set; }
        public ValidationResult ValidationResult { get; set; }
        public bool IsValid()
        {
            ValidationResult = new AnimalEstaConsistenteValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
