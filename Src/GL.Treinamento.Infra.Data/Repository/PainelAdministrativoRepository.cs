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
    public class PainelAdministrativoRepository : Repository<PainelAdministrativo>, IPainelAdministrativoRepository
    {
        public PainelAdministrativoRepository(TreinamentoContext context) : base(context)
        {

        }

        public override void Remover(Guid id)
        {
            base.Remover(id);
        }

        public override IEnumerable<PainelAdministrativo> ObterTodos()
        {
            var cn = Db.Database.Connection;
            var sql = @"SELECT * FROM AspNetUserClaims";

            return cn.Query<PainelAdministrativo>(sql);
        }

        public override PainelAdministrativo ObterPorId(Guid id)
        {
            var cn = Db.Database.Connection;
            var sql = @"SELECT * FROM AspNetUserClaims a WHERE a.Id = @sid ";
            var painelAdm = cn.Query<PainelAdministrativo>(sql, new { sid = id });
            return painelAdm.FirstOrDefault();
        }

        public  PainelAdministrativo ObterPorInt(int id)
        {
            var cn = Db.Database.Connection;
            var sql = @"SELECT * FROM AspNetUserClaims AS ac
                       WHERE ac.Id = @sid ";
            var painelAdm = cn.Query<PainelAdministrativo>(sql, new { sid = id });
            return painelAdm.FirstOrDefault();
        }
    }
}
