using GL.Treinamento.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GL.Treinamento.Domain.Interfaces.Services
{
   public interface IPainelAdministrativoService :IDisposable
    {
        PainelAdministrativo Adicionar(PainelAdministrativo painelAdministrativo);

        PainelAdministrativo ObterPorInt(int id);
        IEnumerable<PainelAdministrativo> ObterTodos();
        PainelAdministrativo Atualizar(PainelAdministrativo painelAdministrativo);
    }
}
