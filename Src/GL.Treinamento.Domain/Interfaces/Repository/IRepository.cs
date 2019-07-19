using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GL.Treinamento.Domain.Interfaces.Repository
{
    //REPOSITÓRIO GENERICO
    public interface IRepository<TEntity> : IDisposable where TEntity : class //TEntity DEFINE QUE O IRepository É GENERICO, IDisposable torna a classe destrutível
    {
        TEntity Adicionar(TEntity obj);
        TEntity ObterPorId(Guid id);
        IEnumerable<TEntity> ObterTodos();
        TEntity Atualizar(TEntity obj);
        void Remover(Guid id);
        IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate); //EXPRESSÃO GENERICA QUE SERVE PARA QUALQUER CAMPO DE QUALQUER ENTIDADE
        int SaveChanges(); 
    }
}
