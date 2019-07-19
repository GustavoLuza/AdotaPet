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
    public class MantimentosRepository :Repository<Mantimentos>, IMantimentoRepository
    {
        public MantimentosRepository(TreinamentoContext context) :base(context)
        {

        }

        public IEnumerable<Mantimentos> ObterAtivos()
        {
            return Buscar(m => m.Ativo);
        }

        public override void Remover(Guid id)
        {
            var mantimento = ObterPorId(id);
            mantimento.Ativo = false;
            Atualizar(mantimento);
        }

        public override IEnumerable<Mantimentos> ObterTodos()
        {
            var cn = Db.Database.Connection;
            var sql = @"SELECT * FROM MANTIMENTOS";
            return cn.Query<Mantimentos>(sql);
        }

        public override Mantimentos ObterPorId(Guid id)
        {
            var cn = Db.Database.Connection;
            var sql = @"SELECT * FROM MANTIMENTOS a WHERE a.MantimentoId = @sid";
            var mantimento = cn.Query<Mantimentos>(sql, new { sid = id });
            return mantimento.FirstOrDefault();
        }
    }
}
