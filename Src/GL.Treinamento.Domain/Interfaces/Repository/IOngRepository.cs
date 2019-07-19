using GL.Treinamento.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GL.Treinamento.Domain.Interfaces.Repository
{
    public interface IOngRepository : IRepository<Ong>
    {
        IEnumerable<Ong> ObterAtivos();
        Ong ObterPorCNPJ(string CNPJ);
        Ong ObterPorEmail(string email);
    }
}
