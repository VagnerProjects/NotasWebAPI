using Microsoft.EntityFrameworkCore;
using NotasWebAPI.Contexto;
using NotasWebAPI.Repositorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotasWebAPI.Repositorios
{
    public class Repositorio<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected CelinaDbContext ctx;

        public Repositorio()
        {
            ctx = new CelinaDbContext();

        }

        public void Adicionar(TEntity obj)
        {
            ctx.Set<TEntity>().Add(obj);
            ctx.SaveChanges();
        }

        public TEntity Find(params object[] key)
        {
            return ctx.Set<TEntity>().Find(key);
        }

        public void Atualizar(TEntity obj)
        {
            ctx.Entry(obj).State = EntityState.Modified;
            ctx.SaveChanges();
        }
        public void Excluir(Func<TEntity, bool> predicate)
        {
            ctx.Set<TEntity>()
                .Where(predicate).ToList()
                .ForEach(del => ctx.Set<TEntity>().Remove(del));

            ctx.SaveChanges();
        }

        public void Dispose()
        {
            if (ctx != null)
            {
                ctx.Dispose();
            }
            GC.SuppressFinalize(this);
        }

        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return ctx.Set<TEntity>().Where(predicate).AsQueryable();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return ctx.Set<TEntity>();
        }
    }
}
