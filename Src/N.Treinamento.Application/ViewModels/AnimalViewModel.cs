using GL.Treinamento.Domain.Enum;
using GL.Treinamento.Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N.Treinamento.Application.ViewModels
{
    public class AnimalViewModel
    {
        public AnimalViewModel()
        {
            AnimalId = Guid.NewGuid();
        }

        [Key]
        public Guid AnimalId { get; set; }

        [Required(ErrorMessage = "Preencha o campo nome do animal")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        [DisplayName("Nome do animal")]
        public string NomeAnimal { get; set; }

        [Required(ErrorMessage = "Selecione a cor da pelagem")]
        [DisplayName("Cor da pelagem")]
        public Enums.CorPelagem CorPelagem { get; set; }

        [Required(ErrorMessage = "Selecione a espécie do animal")]
        [DisplayName("Espécie")]
        public Enums.EspecieAnimal Especie { get; set; }

        [Required(ErrorMessage = "Selecione o porte do animal")]
        public Enums.PorteAnimal Porte { get; set; }
        //public string PorteDescicao => GetPorte();  //MÉTODO PARA FAZER A CONVERSÃO
         
        [ScaffoldColumn(false)]
        [DisplayName("O animal possui alguma doença?")]
        public Guid DoencaId { get; set; }

        [ScaffoldColumn(false)]
        [Required(ErrorMessage = "Selecione a raça do animal")]
        [DisplayName("Raça")]
        public Guid RacaId { get; set; }
           
        [Required(ErrorMessage = "Selecione se o animal é castrado")]
        [DisplayName("O animal é castrado?")]
        public Enums.RespostasSimNao Castrado { get; set; }

        [Required(ErrorMessage = "Selecione se o animal é vermifugado")]
        [DisplayName("O animal é vermifugado?")]
        public Enums.RespostasSimNao Vermifugado { get; set; }

        [Required(ErrorMessage = "Selecione se o animal é vacinado")]
        [DisplayName("O animal é vacinado?")]
        public Enums.RespostasSimNao Vacinado { get; set; }

        [Required(ErrorMessage = "Selecione o sexo do animal")]
        public Enums.SexoAnimais Sexo { get; set; }

        [ScaffoldColumn(false)]
        public bool Ativo { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }

        [ScaffoldColumn(false)]
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }

        //AQUI CONVERTE AS SIGLAS VINDAS DO BANCO PARA EXIBIR NA TELA A PALAVRA INTEIRA
        /*internal string GetPorte()
        {
            switch (Porte)
            {
                case 'M':
                    return "Médio";
                case 'G':
                    return "Grande";
                case 'P':
                    return "Pequeno";
                default:
                    return "Extra grande";
            }
        }*/
     
        // == 'P' ? "Pequeno" : Porte == 'M' ? "Médio" : Porte == 'G' ? "Grande" : "Extra grande";    OUTRA FORMA DE REALIZAR A CONVERSÃO
    }

}
