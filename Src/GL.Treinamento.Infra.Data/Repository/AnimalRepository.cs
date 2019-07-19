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
    public class AnimalRepository :Repository<Animal>, IAnimalRepository
    {
        public AnimalRepository(TreinamentoContext context) :base(context)
        {

        }

        public IEnumerable<Animal> ObterAtivos()
        {
            return Buscar(a => a.Ativo);
        }

        public override void Remover(Guid id)
        {
            var animal = ObterPorId(id);
            animal.Ativo = false;
            Atualizar(animal);
        }

        public override IEnumerable<Animal> ObterTodos()
        {
            var cn = Db.Database.Connection;
            var sql = @"SELECT * FROM ANIMAIS";
            return cn.Query<Animal>(sql);
        }

        public override Animal ObterPorId(Guid id)
        {
            var cn = Db.Database.Connection;
            var sql = @"SELECT * FROM ANIMAIS a WHERE a.AnimalId = @sid";
            var animal = cn.Query<Animal>(sql, new { sid = id });
            return animal.FirstOrDefault();
        }
    }
}
