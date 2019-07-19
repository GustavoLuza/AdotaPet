using GL.Treinamento.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N.Treinamento.Application.ViewModels
{
    public class OngViewModel
    {
        public OngViewModel()
        {
            OngId = Guid.NewGuid();
            Enderecos = new List<EnderecoViewModel>();
        }
        [Key]
        public Guid OngId { get; set; }

        [Required(ErrorMessage = "Preencha o campo nome fantasia")]
        [MaxLength(200, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        [DisplayName("Nome fantasia")]
        public string NomeFantasia { get; set; }

        [Required(ErrorMessage = "Preencha o campo CNPJ")]
        [MaxLength(14, ErrorMessage = "Máximo {0} caracteres")]
        public string CNPJ { get; set; }

        [MaxLength(10, ErrorMessage = "Máximo {0} caracteres")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Preencha o campo celular")]
        [MaxLength(12, ErrorMessage = "Máximo {0} caracteres")]
        public string Celular { get; set; }

        [Required(ErrorMessage = "Preencha o campo E-mail")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
        [EmailAddress(ErrorMessage = "Preencha um E-mail válido")]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [ScaffoldColumn(false)]
        public bool Ativo { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }

        public virtual ICollection<EnderecoViewModel> Enderecos { get; set; }

        [ScaffoldColumn(false)]
        [DisplayName("Responsável")]
        public Guid ClienteId { get; set; }

    }
}
