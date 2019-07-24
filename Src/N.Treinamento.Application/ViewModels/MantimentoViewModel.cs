using GL.Treinamento.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N.Treinamento.Application.ViewModels
{
    public class MantimentoViewModel
    {
        public MantimentoViewModel()
        {
            MantimentoId = Guid.NewGuid();
        }

        [Key]
        public Guid MantimentoId { get; set; }

        [ScaffoldColumn(false)]
        [DisplayName("ONG")]
        public Guid OngId { get; set; }

        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        [DisplayName("Complemento/Descrição")]
        public string Descricao { get; set; }

        [ScaffoldColumn(false)]
        public int CodigoIdentificacao { get; set; }

        [DisplayName("Data de validade")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime DataValidade { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }

        [Required(ErrorMessage = "Selecione se o item")]
        public Enums.DescricaoMantimentos Item { get; set; }

        [Required(ErrorMessage = "Selecione a quantidade")]
        public Enums.Quantidade Quantidade { get; set; }

        [Required(ErrorMessage = "Selecione o tipo")]
        public Enums.TipoMantimento Tipo { get; set; }

        [ScaffoldColumn(false)]
        public bool Ativo { get; set; }

        [ScaffoldColumn(false)]
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }
    }
}
