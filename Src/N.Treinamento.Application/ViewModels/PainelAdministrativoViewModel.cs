using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N.Treinamento.Application.ViewModels
{
   public class PainelAdministrativoViewModel
    {
       /* public PainelAdministrativoViewModel()
        {
            UserId = Guid.NewGuid();
        }*/
        
        [DisplayName("Usuário")]
        [Required(ErrorMessage = "Selecione o campo usuário")]
        public Guid UserId { get; set; }

        [DisplayName("Grupo da permissão")]
        [Required(ErrorMessage = "Selecione o campo grupo de permissões")]
        public string ClaimType { get; set; }

        [DisplayName("Permissões")]
        [Required(ErrorMessage = "Selecione o campo permissões")]
        public string ClaimValue { get; set; }
    }
}
