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
    public class OngRepository : Repository<Ong>, IOngRepository
    {
        public OngRepository(TreinamentoContext context) :base(context)
        {

        }

        public IEnumerable<Ong> ObterAtivos()
        {
            return Buscar(o => o.Ativo);
        }

        public Ong ObterPorCNPJ(string CNPJ)
        {
            return Buscar(o => o.CNPJ == CNPJ).FirstOrDefault();
        }

        public Ong ObterPorEmail(string email)
        {
            return Buscar(o => o.Email == email).FirstOrDefault();
        }

        public override IEnumerable<Ong> ObterTodos()
        {
            var cn = Db.Database.Connection;
            var sql = @"SELECT * FROM ONGS";
            return cn.Query<Ong>(sql);
        }

        public override Ong ObterPorId(Guid id)
        {
            var cn = Db.Database.Connection;
            var sql = @"SELECT * FROM Ongs o " +
                      "LEFT JOIN Enderecos e " +
                      "ON o.OngId = e.OngId " +
                      "WHERE o.OngId = @sid";

            var ong = cn.Query<Ong, Endereco, Ong>(sql,
                (o, e) =>
                {
                    o.Enderecos.Add(e);
                    return o;
                }, new { sid = id }, splitOn: "OngId, EnderecoId");    

            return ong.FirstOrDefault(); 
        }
    }
}
