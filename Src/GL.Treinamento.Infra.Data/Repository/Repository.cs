using GL.Treinamento.Domain.Interfaces.Repository;
using GL.Treinamento.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GL.Treinamento.Infra.Data.Repository
{
    //REPOSITORIO GENERICO VAI SERVIR COMO AUTOMATIZADOR DE CRUD
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        //MAPEAMENTO DO CONTEXTO
        protected TreinamentoContext Db;

        protected DbSet<TEntity> DbSet;

        
        public Repository(TreinamentoContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>(); //ENCAPSULAMENTO DO DB.SET
        }

        public virtual TEntity Adicionar(TEntity obj)
        {
            var objReturn = DbSet.Add(obj); //CHAMADA DO ENCAPSULAMENTO DO DB.SET
  
            return objReturn;
        }

        public virtual TEntity Atualizar(TEntity obj)//VIRTUAL PERMITE SOBREESCREVER O MÉTODO
        {
            var entry = Db.Entry(obj); //ENTRADA
            DbSet.Attach(obj); //ATACHAR O OBJETO
            entry.State = EntityState.Modified; //ESTADO DA ENTRADA É MODIFICADO
            return obj; 
        }

        public IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate); //RETORNA UMA EXPRESSÃO LAMBDA QUE É O PREDICATE
        }
        public void Dispose()
        {
            //O DISPOSE LIBERA RECURSOS DO SO REFERENTE A JANELA ABERTA, PORÉM CONTINUA OCUPANDO MEMORIA
            Db.Dispose();
            GC.SuppressFinalize(this);
        }

        public virtual TEntity ObterPorId(Guid id) //VIRTUAL PERMITE SOBREESCREVER O MÉTODO
        {
            return DbSet.Find(id);
        }

        public virtual IEnumerable<TEntity> ObterTodos()//VIRTUAL PERMITE SOBREESCREVER O MÉTODO
        {
            return DbSet.ToList();
        }

        public virtual void Remover(Guid id)//VIRTUAL PERMITE SOBREESCREVER O MÉTODO
        {
            DbSet.Remove(DbSet.Find(id));

        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }
    }
}
