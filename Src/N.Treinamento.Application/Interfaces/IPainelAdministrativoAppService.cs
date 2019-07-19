using GL.Treinamento.Domain.Entities;
using N.Treinamento.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N.Treinamento.Application.Interfaces
{
   public interface IPainelAdministrativoAppService :IDisposable
    {
        PainelAdministrativoViewModel Adicionar(PainelAdministrativoViewModel painelAdministrativo);
        PainelAdministrativoViewModel ObterPorInt(int id);
        IEnumerable<PainelAdministrativoViewModel> ObterTodos();
        PainelAdministrativoViewModel Atualizar(PainelAdministrativoViewModel painelAdministrativo);
    }
}
