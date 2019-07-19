using GL.Treinamento.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GL.Treinamento.Domain.Interfaces.Services
{
   public interface IClienteService : IDisposable //É IMPLEMENTADO O IDisposable PARA QUE SEJA POSSÍVEL DESTRUIR A CLASSE QUE ESTÁ IMPLEMENTANDO ESTA CLASSE
    {
        Cliente Adicionar(Cliente cliente);
        Cliente ObterPorId(Guid id);
        IEnumerable<Cliente> ObterTodos();
        Cliente ObterPorCpf(string cpf);
        Cliente ObterPorEmail(string email);
        IEnumerable<Cliente> ObterAtivos();
        Cliente Atualizar(Cliente cliente);
        void Remover(Guid id);
    }
}
