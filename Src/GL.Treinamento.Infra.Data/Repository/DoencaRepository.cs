using Dapper;
using GL.Treinamento.Domain.Entities;
using GL.Treinamento.Domain.Interfaces.Repository;
using GL.Treinamento.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GL.Treinamento.Infra.Data.Repository
{
    public class DoencaRepository : Repository<Doenca>, IDoencaRepository
    {
        public DoencaRepository(TreinamentoContext context) :base(context)
        {

        }

        public Doenca ObterPorDoenca(string nomeDoenca)
        {
            return Buscar(d => d.NomeDoenca == nomeDoenca).FirstOrDefault();
        }

        public override void Remover(Guid id)
        {
            base.Remover(id);
        }

        public override IEnumerable<Doenca> ObterTodos()
        {
            var cn = Db.Database.Connection;
            var sql = @"SELECT * FROM DOENCAS";
            return cn.Query<Doenca>(sql);
        }

        public override Doenca ObterPorId(Guid id)
        {
            var cn = Db.Database.Connection;
            var sql = @"SELECT * FROM DOENCAS d WHERE D.DoencaId = @sid";
            var doenca = cn.Query<Doenca>(sql, new { sid = id });
            return doenca.FirstOrDefault();
        }
    }
}
