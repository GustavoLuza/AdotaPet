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
    public class RacaRepository : Repository<Raca>, IRacaRepository
    {
        public RacaRepository(TreinamentoContext context) : base (context)
        {

        }

        public Raca ObterPorRaca(string nomeRaca)
        {
            return Buscar(r => r.NomeRaca == nomeRaca).FirstOrDefault();
        }

        public override IEnumerable<Raca> ObterTodos()
        {
            var cn = Db.Database.Connection;
            var sql = @"SELECT * FROM RACAS";
            return cn.Query<Raca>(sql);
        }

        public override Raca ObterPorId(Guid id)
        {
            var cn = Db.Database.Connection;
            var sql = @"SELECT * FROM RACAS r WHERE r.RacaId = @sid";
            var doenca = cn.Query<Raca>(sql, new { sid = id });
            return doenca.FirstOrDefault();
        }
    }
}
