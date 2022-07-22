using Core.DAL;
using Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccessLayer.Concrete.Context.EntityFramework
{
    public class EfRepository<TEntity,TDbContext> : IRepository<TEntity>
        where TEntity : class, IBaseEntity,new()
        where TDbContext : DbContext
    {
        private readonly TDbContext db;
        public EfRepository(TDbContext db)
        {
            this.db = db;
        }
        public bool Add(TEntity entity)
        {
            db.Add(entity);
            return db.SaveChanges() > 0 ? true : false;
        }
        public bool Update(TEntity entity)
        {
            db.Update(entity);
            return db.SaveChanges() > 0 ? true : false;
        }
        public bool Delete(TEntity entity)
        {
            db.Update(entity);
            return db.SaveChanges() > 0 ? true : false;
        }
        public IEnumerable<TEntity> Get()
        {
            return db.Set<TEntity>();
        }
        public IEnumerable<TEntity> GetEntity(Expression<Func<TEntity,bool>> expression=null,
            string[] navProperty =null
                        )
        {
            IQueryable<TEntity> entities = null;
            if (expression==null)
            {
                entities= db.Set<TEntity>();
            }
            else
            {
                entities= db.Set<TEntity>().Where(expression);
            }
            if (navProperty==null)
            {
                return entities;
            }
            else
            {
                foreach (var item in navProperty)
                {
                    entities = entities.Include(item);
                }
                return entities;
            }
        }
        public TEntity Get(int id)
        {
            return db.Set<TEntity>().Find(id);

        }
    }
}
