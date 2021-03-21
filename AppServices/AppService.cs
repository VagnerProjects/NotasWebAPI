using NotasWebAPI.AppServicesInterface;
using NotasWebAPI.ServicesInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotasWebAPI.AppServices
{
    public class AppService<TEntity> : IAppService<TEntity> where TEntity:class
    {
        private readonly IService<TEntity> _service;
        public AppService(IService<TEntity> service)
        {
            _service = service;
        }
        public void Adicionar(TEntity obj)
        {
            _service.Adicionar(obj);
        }

        public void Atualizar(TEntity obj)
        {
            _service.Atualizar(obj);
        }

        public void Dispose()
        {
            _service.Dispose();
        }

        public void Excluir(Func<TEntity, bool> predicate)
        {
            _service.Excluir(predicate);
        }

        public TEntity Find(params object[] key)
        {
            return _service.Find(key);
        }

        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return _service.Get(predicate);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _service.GetAll();
        }
    }
}
