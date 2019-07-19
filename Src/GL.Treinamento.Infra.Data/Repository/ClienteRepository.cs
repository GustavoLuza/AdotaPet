using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using GL.Treinamento.Domain.Entities;
using GL.Treinamento.Infra.Data.Context;

namespace GL.Treinamento.Infra.Data.Repository
{
    //AQUI VAI IMPLEMENTAR O QUE NÃO TEM NO REPOSITÓRIO GENERICO
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(TreinamentoContext context) :base(context)
        {

        }
        public IEnumerable<Cliente> ObterAtivos()
        {
           return Buscar(c => c.Ativo);
        }

        public Cliente ObterPorCpf(string cpf)
        {
            return Buscar(c => c.CPF == cpf).FirstOrDefault();
        }

        public Cliente ObterPorEmail(string email)
        {
            return Buscar(c => c.Email == email).FirstOrDefault();
        }

        //SOBREESCREVENDO O METODO DO REPOSITORY GENERICO PARA QUE QUANDO CLICAR EM REMOVER O CLIENTE, SETAR O ESTADO COMO INATIVO MANTENDO O CLIENTE NA BASE
        public override void Remover(Guid id)
        {
            var cliente = ObterPorId(id); 
            cliente.Ativo = false; 
            Atualizar(cliente); 
        }

        //SOBREESCREVENDO O METODO DO REPOSITORY GENERICO PARA QUE LISTE TODOS BASEADO NA DATA DE CADASTRO DO CLIENTE
        public override IEnumerable<Cliente> ObterTodos()
        {
            var cn = Db.Database.Connection;
            var sql = @"SELECT * FROM CLIENTES";
            return cn.Query<Cliente>(sql);    
        }

        public override Cliente ObterPorId(Guid id)
        {
            var cn = Db.Database.Connection;
            var sql = @"SELECT * FROM Clientes c " +
                      "LEFT JOIN Enderecos e " +
                      "ON c.ClienteId = e.ClienteId " +
                      "WHERE c.ClienteId = @sid";

            var cliente = cn.Query<Cliente, Endereco, Cliente>(sql,
                (c, e) =>
                {
                    c.Enderecos.Add(e);
                    return c;
                }, new { sid = id }, splitOn: "ClienteId, EnderecoId");    //SPLITON DIZ COMO A QUERY VAI SER QUEBRADA, NO CASO PELO ClienteId E EnderecoId( sempre vai ser a pk)

            return cliente.FirstOrDefault();  //NÃO VAI RETORNAR MAIS DE UM RESULTADO, PORÉM COMO O CLIENTE É UM IEnumerable, PRECISA USAR O FirstOrDefault
        }
    }
}
