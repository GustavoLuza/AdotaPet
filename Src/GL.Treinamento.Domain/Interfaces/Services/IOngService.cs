using GL.Treinamento.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GL.Treinamento.Domain.Interfaces.Services
{
    public interface IOngService :IDisposable
    {
        Ong Adicionar(Ong ong);
        Ong ObterPorId(Guid id);
        IEnumerable<Ong> ObterTodos();
        IEnumerable<Ong> ObterAtivos();
        Ong ObterPorCNPJ(string cnpj);
        Ong ObterPorEmail(string email);
        Ong Atualizar(Ong ong);
        void Remover(Guid id);
    }
}
