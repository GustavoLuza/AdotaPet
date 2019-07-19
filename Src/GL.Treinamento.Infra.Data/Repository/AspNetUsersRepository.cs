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
   public class AspNetUsersRepository : Repository<AspNetUsers>, IAspNetUsersRepository
    {
        public AspNetUsersRepository(TreinamentoContext context) : base(context)
        {

        }

        public override IEnumerable<AspNetUsers> ObterTodos()
        {
            var cn = Db.Database.Connection;
            var sql = @"SELECT * FROM AspNetUsers";
            return cn.Query<AspNetUsers>(sql);
        }

        public override AspNetUsers ObterPorId(Guid id)
        {
            var cn = Db.Database.Connection;
            var sql = @"SELECT * FROM AspNetUsers a WHERE a.Id = @sid ";
            var usuarios = cn.Query<AspNetUsers>(sql, new { sid = id });
            return usuarios.FirstOrDefault();
        }

    }
}
