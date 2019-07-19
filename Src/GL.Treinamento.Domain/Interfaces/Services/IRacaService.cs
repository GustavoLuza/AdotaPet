using GL.Treinamento.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GL.Treinamento.Domain.Interfaces.Services
{
    public interface IRacaService :IDisposable
    {
        Raca Adicionar(Raca raca);
        Raca ObterPorId(Guid id);
        Raca ObterPorRaca(string nomeRaca);
        IEnumerable<Raca> ObterTodos();
        Raca Atualizar(Raca raca);
        void Remover(Guid id);
    }
}
