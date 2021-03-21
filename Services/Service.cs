using NotasWebAPI.Contexto;
using NotasWebAPI.RepositorioInterfaces;
using NotasWebAPI.ServicesInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotasWebAPI.Services
{
    public class Service<TEntity>:IService<TEntity> where TEntity:class
    {
        private readonly IRepository<TEntity> _repository;

        public Service(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public void Adicionar(TEntity obj)
        {
            _repository.Adicionar(obj);
        }

        public TEntity Find(params object[] key)
        {
            return _repository.Find(key);
        }

        public void Atualizar(TEntity obj)
        {
            _repository.Atualizar(obj);
        }
        public void Excluir(Func<TEntity, bool> predicate)
        {
            _repository.Excluir(predicate);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return _repository.Get(predicate);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
