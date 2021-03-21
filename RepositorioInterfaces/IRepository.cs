using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotasWebAPI.RepositorioInterfaces
{
    public interface IRepository<TEntity>: IDisposable where TEntity: class
    {
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);
        TEntity Find(params object[] key);
        void Atualizar(TEntity obj);
        void Adicionar(TEntity obj);
        void Excluir(Func<TEntity, bool> predicate);
    }
}
