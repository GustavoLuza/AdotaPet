using GL.Treinamento.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GL.Treinamento.Domain.Interfaces.Services
{
    public interface IDoencaService :IDisposable
    {
        Doenca Adicionar(Doenca doenca);
        Doenca ObterPorId(Guid id);
        Doenca ObterPorDoenca(string nomeDoenca);
        IEnumerable<Doenca> ObterTodos();
        Doenca Atualizar(Doenca doenca);
        void Remover(Guid id);
    }
}
