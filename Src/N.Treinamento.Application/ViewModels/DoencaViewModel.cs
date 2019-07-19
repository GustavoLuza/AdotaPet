using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N.Treinamento.Application.ViewModels
{
   public class DoencaViewModel
    {
        public DoencaViewModel()
        {
            DoencaId = Guid.NewGuid();
        }

        [Key]
        public Guid DoencaId { get; set; }

        [Required(ErrorMessage = "Preencha o campo nome da doença")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        [DisplayName("Doença")]
        public string NomeDoenca { get; set; }

        [ScaffoldColumn(false)]
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }
    }
}
