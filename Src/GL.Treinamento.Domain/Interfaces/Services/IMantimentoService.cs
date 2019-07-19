using GL.Treinamento.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GL.Treinamento.Domain.Interfaces.Services
{
    public interface IMantimentoService :IDisposable
    {
        Mantimentos Adicionar(Mantimentos mantimentos);
        Mantimentos ObterPorId(Guid id);
        IEnumerable<Mantimentos> ObterTodos();
        IEnumerable<Mantimentos> ObterAtivos();
        Mantimentos Atualizar(Mantimentos mantimentos);
        void Remover(Guid id);
    }
}
