using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N.Treinamento.Application.ViewModels
{
    public class RacaViewModel
    {
        public RacaViewModel()
        {
            RacaId = Guid.NewGuid();
        }

        [Key]
        public Guid RacaId { get; set; }

        [Required(ErrorMessage = "Preencha o campo raça")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        [DisplayName("Raça")]
        public string NomeRaca { get; set; }

        [ScaffoldColumn(false)]
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }
    }
}
